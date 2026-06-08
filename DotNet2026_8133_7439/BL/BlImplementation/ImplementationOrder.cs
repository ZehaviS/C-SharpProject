//using BlApi;
//using BO;

//namespace BlImplementation
//{
//    internal class ImplementationOrder : IOrder
//    {
//        public List<SaleInProduct> AddProductToOrder(Order order, int productId, int count)
//        {
//            if (order.ProductInOrder == null)
//                order.ProductInOrder = new List<ProductInOrder>();

//            var existing = order.ProductInOrder.FirstOrDefault(x => x.ProductId == productId);

//            if (existing != null)
//                existing.Count += count;
//            else
//            {
//                order.ProductInOrder.Add(new ProductInOrder
//                {
//                    ProductId = productId,
//                    ProductName = $"Product {productId}",
//                    BasePrice = 100, // דמו
//                    Count = count
//                });
//            }

//            return null;
//        }

//        public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
//        {
//            productInOrder.FinalPrice = productInOrder.BasePrice * productInOrder.Count;
//        }

//        public void CalcTotalPrice(Order order)
//        {
//            double total = 0;

//            foreach (var item in order.ProductInOrder)
//            {
//                CalcTotalPriceForProduct(item);
//                total += item.FinalPrice;
//            }

//            order.TotalPrice = total;
//        }

//        public void DoOrder(Order order)
//        {
//            CalcTotalPrice(order);
//            order.ProductInOrder.Clear();
//            order.TotalPrice = 0;
//        }

//        public void SearchSaleForProduct(ProductInOrder productInOrder, bool isPreferedCustomer)
//        {
//            // לא חובה בשלב שלך — אפשר להשאיר ריק
//        }
//    }
//}
using BlApi;
using BO;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class ImplementationOrder : IOrder
    {
        private readonly IDal _dal = DalApi.Factory.Get;

        public Order CreateOrder(bool isPreferedCustomer = false)
        {
            return new Order
            {
                ProductInOrder = new List<ProductInOrder>(),
                IsPreferedCustomer = isPreferedCustomer,
                TotalPrice = 0,
                DiscountApplied = 0
            };
        }

        // ================= ADD PRODUCT =================
        public List<SaleInProduct> AddProductToOrder(Order order, int productId, int count)
        {
            order.ProductInOrder ??= new List<ProductInOrder>();

            var product = _dal.product.Read(productId);
            if (product == null)
                throw new Exception("Product not found");

            var existing = order.ProductInOrder.FirstOrDefault(x => x.ProductId == productId);

            if (existing != null)
            {
                int newQuantity = existing.Count + count;

                if (newQuantity <= 0)
                {
                    order.ProductInOrder.Remove(existing);
                    CalcTotalPrice(order);
                    return new List<SaleInProduct>();
                }

                if (newQuantity > product.ProductCount)
                    throw new Exception($"Not enough stock. Requested: {newQuantity}, Available: {product.ProductCount}");

                existing.Count = newQuantity;
            }
            else
            {
                if (count <= 0)
                    throw new Exception("Cannot add a new product with zero or negative quantity.");

                if (count > product.ProductCount)
                    throw new Exception($"Not enough stock. Requested: {count}, Available: {product.ProductCount}");

                existing = new ProductInOrder
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    BasePrice = product.ProductPrice,
                    Count = count,
                    Sales = new List<SaleInProduct>()
                };

                order.ProductInOrder.Add(existing);
            }

            SearchSaleForProduct(existing, order.IsPreferedCustomer);
            CalcTotalPriceForProduct(existing);
            CalcTotalPrice(order);

            return existing.Sales ?? new List<SaleInProduct>();
        }

        // ================= PRICE PER PRODUCT =================
        public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
        {
            if (productInOrder == null)
                return;

            int remainingQuantity = productInOrder.Count;
            double totalPrice = 0;
            var appliedSales = new List<SaleInProduct>();

            if (productInOrder.Sales != null)
            {
                foreach (var sale in productInOrder.Sales)
                {
                    if (remainingQuantity < sale.Amount_to_sale)
                        continue;

                    int timesUsed = remainingQuantity / sale.Amount_to_sale;
                    totalPrice += timesUsed * sale.Amount_to_sale * sale.Price_per_one;
                    remainingQuantity -= timesUsed * sale.Amount_to_sale;
                    appliedSales.Add(sale);

                    if (remainingQuantity == 0)
                        break;
                }
            }

            totalPrice += remainingQuantity * productInOrder.BasePrice;
            productInOrder.FinalPrice = totalPrice;
            productInOrder.Sales = appliedSales;
        }

        // ================= TOTAL PRICE =================
        public void CalcTotalPrice(Order order)
        {
            if (order.ProductInOrder == null)
            {
                order.TotalPrice = 0;
                order.DiscountApplied = 0;
                return;
            }

            double total = 0;
            double discount = 0;

            foreach (var item in order.ProductInOrder)
            {
                CalcTotalPriceForProduct(item);
                total += item.FinalPrice;
                discount += item.Count * item.BasePrice - item.FinalPrice;
            }

            order.TotalPrice = total;
            order.DiscountApplied = discount;
        }

        // ================= CHECKOUT =================
        public void DoOrder(Order order)
        {
            if (order.ProductInOrder == null || order.ProductInOrder.Count == 0)
                return;

            foreach (var productInOrder in order.ProductInOrder)
            {
                var storedProduct = _dal.product.Read(productInOrder.ProductId);
                if (storedProduct == null)
                    throw new Exception($"Product with ID {productInOrder.ProductId} does not exist.");

                if (storedProduct.ProductCount < productInOrder.Count)
                    throw new Exception($"Cannot complete order. Not enough stock for product '{storedProduct.ProductName}'.");

                _dal.product.Update(storedProduct with { ProductCount = storedProduct.ProductCount - productInOrder.Count });
            }

            CalcTotalPrice(order);
            order.ProductInOrder.Clear();
            order.TotalPrice = 0;
            order.DiscountApplied = 0;
        }

        // ================= SALES =================
        public void SearchSaleForProduct(ProductInOrder productInOrder, bool isPreferedCustomer)
        {
            if (productInOrder == null || productInOrder.Count <= 0)
                return;

            var now = DateTime.Now;

            var relevantSales = _dal.sale.ReadAll(sale =>
                sale != null &&
                sale.ProductId == productInOrder.ProductId &&
                (sale.DateStart == null || sale.DateStart <= now) &&
                (sale.DateEnd == null || sale.DateEnd >= now) &&
                productInOrder.Count >= sale.ProductsCountToSale &&
                (isPreferedCustomer || !sale.OnlyClubCustomers))
                .Where(s => s != null)
                .Select(s => s!.ToBO())
                .Select(s => new SaleInProduct
                {
                    SaleId = s.SaleId,
                    Amount_to_sale = s.ProductsCountToSale,
                    Price_per_one = s.PriceAfterSale,
                    IsForAllClients = !s.OnlyClubCustomers
                })
                .OrderBy(s => s.Amount_to_sale)
                .ToList();

            productInOrder.Sales = relevantSales;
        }
    }
}