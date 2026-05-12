using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal;

internal class ImplementationSale : Isale
{
    private static readonly string s_file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xml", "sales.xml");

    private XElement Load()
    {
        if (!File.Exists(s_file)) return new XElement("ArrayOfSale");
        return XElement.Load(s_file);
    }

    private void Save(XElement root) => root.Save(s_file);

    public int Create(Sale item)
    {
        var root = Load();
        int id = Config.SaleNum;
        var sale = new XElement("Sale",
            new XElement("SaleId", id),
            new XElement("ProductId", item.ProductId),
            new XElement("ProductsCountToSale", item.ProductsCountToSale),
            new XElement("PriceAfterSale", item.PriceAfterSale),
            new XElement("OnlyClubCustomers", item.OnlyClubCustomers)
        );
        if (item.DateStart != null) sale.Add(new XElement("DateStart", item.DateStart.Value.ToString("o")));
        if (item.DateEnd != null) sale.Add(new XElement("DateEnd", item.DateEnd.Value.ToString("o")));
        root.Add(sale);
        Save(root);
        return id;
    }

    private static Sale ToSale(XElement el) => new Sale(
        (int)el.Element("SaleId"),
        (int)el.Element("ProductId"),
        (int)el.Element("ProductsCountToSale"),
        double.Parse(el.Element("PriceAfterSale").Value),
        bool.Parse(el.Element("OnlyClubCustomers").Value),
        el.Element("DateStart") != null ? DateTime.Parse(el.Element("DateStart").Value) : (DateTime?)null,
        el.Element("DateEnd") != null ? DateTime.Parse(el.Element("DateEnd").Value) : (DateTime?)null
    );

    public Sale? Read(int id)
    {
        var root = Load();
        var el = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("SaleId") == id);
        if (el == null) throw new DO.ItemNotFoundException("sale not found");
        return ToSale(el);
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        var all = ReadAll();
        return all.FirstOrDefault(s => s != null && filter(s));
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        var root = Load();
        var list = root.Elements("Sale").Select(el => (Sale?)ToSale(el)).ToList();
        if (filter == null) return list;
        return list.Where(s => s != null && filter(s)).ToList();
    }

    public void Update(Sale item)
    {
        var root = Load();
        var el = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("SaleId") == item.SaleId);
        if (el == null) throw new DO.ItemNotFoundException("sale not found");
        el.SetElementValue("ProductId", item.ProductId);
        el.SetElementValue("ProductsCountToSale", item.ProductsCountToSale);
        el.SetElementValue("PriceAfterSale", item.PriceAfterSale);
        el.SetElementValue("OnlyClubCustomers", item.OnlyClubCustomers);
        if (item.DateStart != null) el.SetElementValue("DateStart", item.DateStart.Value.ToString("o"));
        else el.Element("DateStart")?.Remove();
        if (item.DateEnd != null) el.SetElementValue("DateEnd", item.DateEnd.Value.ToString("o"));
        else el.Element("DateEnd")?.Remove();
        Save(root);
    }

    public void Delete(int id)
    {
        var root = Load();
        var el = root.Elements("Sale").FirstOrDefault(x => (int?)x.Element("SaleId") == id);
        if (el == null) throw new DO.ItemNotFoundException("sale not found");
        el.Remove();
        Save(root);
    }
}
