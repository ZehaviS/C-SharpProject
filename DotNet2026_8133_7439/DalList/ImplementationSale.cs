// ...existing code...
using System;
using System.Linq;
using System.Reflection;
using DalApi;
using DO;
using Tools;
using static Dal.DataSource;

namespace Dal;

internal class ImplementationSale : Isale
{
    public int Create(Sale item)

    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, "Start Create sale");
        Sale s = item with { SaleId = Config.GetNextProductId() };
        Sales.Add(s);
        LogManager.LogMessage(projectName, funcName, $"Created sale id {s.SaleId}");
        return s.ProductId;
    }
    public Sale? Read(int id)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Read sale id {id}");
        var q = from s in Sales
                where s?.SaleId == id
                select s;
        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new ItemNotFoundException("sale not found");

        LogManager.LogMessage(projectName, funcName, $"Read sale id {id}");
        return sale;
   
    }



    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
         var method = MethodBase.GetCurrentMethod()!;
         string projectName = method.DeclaringType?.FullName ?? "DalList";
         string funcName = method.Name;

         LogManager.LogMessage(projectName, funcName, "Start ReadAll sales");
         List<Sale> result;
         if (filter == null)
             result = Sales.ToList();
         else
         {
             var q = from s in Sales
                     where filter(s)
                     select s;
             result = q.ToList();
         }

         LogManager.LogMessage(projectName, funcName, $"Read all sales count {result.Count}");
         return result;

    }
    //
    public Sale? Read(Func<Sale, bool> filter)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, "Start Read sale by filter");
        var result = Sales.FirstOrDefault(filter);
        LogManager.LogMessage(projectName, funcName, result == null ? "Read sale with filter returned null" : $"Read sale id {result.SaleId}");
        return result;
    }
    //
    public void Update(Sale item)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Update sale id {item.SaleId}");
        var q = from s in Sales
                where s?.SaleId == item.SaleId
                select s;
        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new ItemNotFoundException("sale not found");
        Sales.Remove(sale);
        Sales.Add(item);
        LogManager.LogMessage(projectName, funcName, $"Updated sale id {item.SaleId}");

    }

    public void Delete(int id)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Delete sale id {id}");
        var q = from s in Sales
                where s?.SaleId == id
                select s;
        Sale? sale = q.FirstOrDefault();
        if (sale == null)
            throw new ItemNotFoundException("sale not found");

        Sales.Remove(sale);
        LogManager.LogMessage(projectName, funcName, $"Deleted sale id {id}");
    }

}
// ...existing code...
