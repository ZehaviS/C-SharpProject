
using System.Linq;
using System.Reflection;
using DalApi;
using DO;
using Tools;
using static Dal.DataSource;

namespace Dal;

internal class ImplementationProduct : Iproduct
{
    public int Create(Product item)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, "Start Create product");
        Product p = item with { ProductId = Config.GetNextProductId() };
        Products.Add(p);
        LogManager.LogMessage(projectName, funcName, $"Created product id {p.ProductId}");
        return p.ProductId;
    }
    public Product? Read(int id)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Read product id {id}");
        var q = from p in Products
                where p?.ProductId == id
                select p;
        Product prod = q.FirstOrDefault();
        if (prod == null)
            throw new ItemNotFoundException("product not found");

        LogManager.LogMessage(projectName, funcName, $"Read product id {id}");
        return prod;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, "Start Read product by filter");
        var result = Products.FirstOrDefault(filter);
        LogManager.LogMessage(projectName, funcName, result == null ? "Read product with filter returned null" : $"Read product id {result.ProductId}");
        return result;
    }


    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, "Start ReadAll products");
        List<Product> result;
        if (filter == null)
            result = Products.ToList();
        else
        {
            var q = from p in Products
                    where filter(p)
                    select p;
            result = q.ToList();
        }

        LogManager.LogMessage(projectName, funcName, $"Read all products count {result.Count}");
        return result;
    }
    public void Update(Product item)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Update product id {item.ProductId}");
        var q = from p in Products
                where p?.ProductId == item.ProductId
                select p;
        Product prod = q.FirstOrDefault();
        if (prod == null)
            throw new ItemNotFoundException("product not found");
        Products.Remove(prod);
        Products.Add(item);
        LogManager.LogMessage(projectName, funcName, $"Updated product id {item.ProductId}");
    }

    public void Delete(int id)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Delete product id {id}");
        var q = from p in Products
                where p?.ProductId == id
                select p;
        Product prod = q.FirstOrDefault();
        if (prod == null)
            throw new ItemNotFoundException("product not found");

        Products.Remove(prod);
        LogManager.LogMessage(projectName, funcName, $"Deleted product id {id}");
    }


}
// ...existing code...
