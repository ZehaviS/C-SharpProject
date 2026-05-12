// ...existing code...
using System;
using System.Linq;
using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

internal class ImplementationSale : Isale
{

    public int Create(Sale item)

    {
        Sale s = item with { SaleId = Config.GetNextProductId() };
        Sales.Add(s);
        return s.ProductId;
    }
    public Sale? Read(int id)
    {
        var q = from s in Sales
                where s?.SaleId == id
                select s;
        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new ItemNotFoundException("sale not found");

        return sale;
   
    }



    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
         if (filter == null)
            return Sales.ToList();
        var q = from s in Sales
                where filter(s)
                select s;
        return q.ToList();

    }
    //
    public Sale? Read(Func<Sale, bool> filter)
    {
        return Sales.FirstOrDefault(filter);
    }
    //
    public void Update(Sale item)
    {
        var q = from s in Sales
                where s?.SaleId == item.SaleId
                select s;
        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new ItemNotFoundException("sale not found");
        Sales.Remove(sale);
        Sales.Add(item);

    }

    public void Delete(int id)
    {
        var q = from s in Sales
                where s?.SaleId == id
                select s;
        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new ItemNotFoundException("sale not found");

        Sales.Remove(sale);
    }

}
// ...existing code...
