// using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal
{
    internal class SaleImplementation : Isale
    {
        private static readonly string fileName =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xml", "sales.xml");

        private string SALE = "sale";
        private string ID = "id";
        private string PRODUCTID = "product_id";
        private string AMOUNTTOSALE = "amount_to_sale";
        private string COUNTTOSALE = "count_to_sale";
        private string DISCOUNT = "discount";
        private string TOCLUB = "to_club";
        private string STARTDATE = "start_date";
        private string ENDDATE = "end_date";

        private XElement sales;

        public SaleImplementation()
        {
            string? directory = Path.GetDirectoryName(fileName);

            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            sales = File.Exists(fileName)
                ? XElement.Load(fileName)
                : new XElement("sales");
        }

        public Sale Read(int id)
        {
            var saleElement = sales.Elements(SALE)
                .FirstOrDefault(x => x.Element(ID)?.Value == id.ToString());

            if (saleElement == null)
                throw new ItemNotFoundException("sale with id: " + id + " does not exists");

            return CreateSaleFromElement(saleElement);
        }

        public Sale Read(Func<Sale, bool> filter)
        {
            return ReadAll(filter).FirstOrDefault();
        }

        public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
        {
            List<Sale> list = new List<Sale>();

            foreach (var item in sales.Elements(SALE))
            {
                var sale = CreateSaleFromElement(item);

                if (filter == null || filter(sale))
                    list.Add(sale);
            }

            return list;
        }

        public int Create(Sale sale)
        {
            int id = Config.GetSaleId;

            sales.Add(new XElement(SALE,
                new XElement(ID, id),
                new XElement(PRODUCTID, sale.ProductId),
                new XElement(COUNTTOSALE, sale.ProductsCountToSale),
                new XElement(AMOUNTTOSALE, sale.PriceAfterSale),
                new XElement(DISCOUNT, sale.Discount),
                new XElement(TOCLUB, sale.OnlyClubCustomers),
                new XElement(STARTDATE, FormatNullableDate(sale.DateStart)),
                new XElement(ENDDATE, FormatNullableDate(sale.DateEnd))
            ));

            sales.Save(fileName);
            return id;
        }

        private Sale CreateSaleFromElement(XElement element)
        {
            return new Sale()
            {
                SaleId = int.Parse(element.Element(ID)!.Value),
                ProductId = int.Parse(element.Element(PRODUCTID)!.Value),
                ProductsCountToSale = int.Parse(element.Element(COUNTTOSALE)!.Value),
                PriceAfterSale = double.Parse(element.Element(AMOUNTTOSALE)!.Value),
                Discount = double.Parse(element.Element(DISCOUNT)?.Value ?? "0"),
                OnlyClubCustomers = bool.Parse(element.Element(TOCLUB)!.Value),
                DateStart = ParseNullableDate(element.Element(STARTDATE)?.Value),
                DateEnd = ParseNullableDate(element.Element(ENDDATE)?.Value)
            };
        }

        private DateTime? ParseNullableDate(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            return DateTime.TryParse(value, out var result) ? result : throw new FormatException($"Invalid date value: '{value}'");
        }

        private string FormatNullableDate(DateTime? date)
        {
            return date?.ToString("o") ?? string.Empty;
        }

        public void Delete(int id)
        {
            var saleElement = sales.Elements(SALE)
                .FirstOrDefault(x => x.Element(ID)?.Value == id.ToString());

            if (saleElement == null)
                throw new ItemNotFoundException("sale with id: " + id + " does not exists");

            saleElement.Remove();
            sales.Save(fileName);
        }

        public void Update(Sale item)
        {
            var saleElement = sales.Elements(SALE)
                .FirstOrDefault(x => x.Element(ID)?.Value == item.SaleId.ToString());

            if (saleElement == null)
                throw new ItemNotFoundException("sale with id: " + item.SaleId + " does not exists");

            saleElement.Element(PRODUCTID)!.Value = item.ProductId.ToString();
            saleElement.Element(COUNTTOSALE)!.Value = item.ProductsCountToSale.ToString();
            saleElement.Element(AMOUNTTOSALE)!.Value = item.PriceAfterSale.ToString();
            
            // Handle DISCOUNT - create if doesn't exist
            var discountElement = saleElement.Element(DISCOUNT);
            if (discountElement == null)
            {
                saleElement.Add(new XElement(DISCOUNT, item.Discount.ToString()));
            }
            else
            {
                discountElement.Value = item.Discount.ToString();
            }
            
            saleElement.Element(TOCLUB)!.Value = item.OnlyClubCustomers.ToString();
            saleElement.Element(STARTDATE)!.Value = FormatNullableDate(item.DateStart);
            saleElement.Element(ENDDATE)!.Value = FormatNullableDate(item.DateEnd);

            sales.Save(fileName);
        }
    }
}