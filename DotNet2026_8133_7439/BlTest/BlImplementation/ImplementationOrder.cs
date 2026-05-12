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

namespace BlImplementation
{
    internal class ImplementationOrder : IOrder
    {
        private readonly IDal _dal = DalApi.Factory.Get;

        // ================= ADD PRODUCT =================
        public List<SaleInProduct> AddProductToOrder(Order order, int productId, int count)
        {
            order.ProductInOrder ??= new List<ProductInOrder>();

            // 1. להביא מוצר אמיתי מה-DAL
            var product = _dal.product.Read(productId);

            if (product == null)
                throw new Exception("Product not found");

            // 2. לבדוק אם כבר קיים בסל
            var existing = order.ProductInOrder
                .FirstOrDefault(x => x.ProductId == productId);

            if (existing != null)
            {
                existing.Count += count;
            }
            else
            {
                order.ProductInOrder.Add(new ProductInOrder
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    BasePrice = product.ProductPrice, // אמיתי מה-DAL
                    Count = count,
                    Sales = new List<SaleInProduct>()
                });
            }

            // 3. חישוב מחיר כולל
            CalcTotalPrice(order);

            // 4. כרגע אין הנחות → מחזירים רשימה ריקה
            return new List<SaleInProduct>();
        }

        // ================= PRICE PER PRODUCT =================
        public void CalcTotalPriceForProduct(ProductInOrder productInOrder)
        {
            productInOrder.FinalPrice =
                productInOrder.BasePrice * productInOrder.Count;
        }

        // ================= TOTAL PRICE =================
        public void CalcTotalPrice(Order order)
        {
            if (order.ProductInOrder == null)
                return;

            double total = 0;

            foreach (var item in order.ProductInOrder)
            {
                CalcTotalPriceForProduct(item);
                total += item.FinalPrice;
            }

            order.TotalPrice = total;
        }

        // ================= CHECKOUT =================
        public void DoOrder(Order order)
        {
            CalcTotalPrice(order);

            // כאן בעתיד תכתוב שמירה ל-DB / יצירת הזמנה

            order.ProductInOrder?.Clear();
            order.TotalPrice = 0;
        }

        // ================= SALES (שלב מתקדם) =================
        public void SearchSaleForProduct(ProductInOrder productInOrder, bool isPreferedCustomer)
        {
            // בהמשך נחבר לטבלת Sale מה-DAL
        }
    }
}