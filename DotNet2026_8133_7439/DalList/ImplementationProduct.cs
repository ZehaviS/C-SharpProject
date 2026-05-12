
using System.Linq;
using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

internal class ImplementationProduct : Iproduct
{

    public int Create(Product item)
    {
        Product p = item with { ProductId = Config.GetNextProductId() };
        Products.Add(p);
        return p.ProductId;
    }
    public Product? Read(int id)
    {
        var q = from p in Products
                where p?.ProductId == id
                select p;
        Product prod = q.FirstOrDefault();
        if (prod == null)
            throw new ItemNotFoundException("product not found");

        return prod;
    }
    public Product? Read(Func<Product, bool> filter)
    {
        return Products.FirstOrDefault(filter);
    }


    public List<Product> ReadAll(Func<Product, bool>? filter = null)
    {
        if (filter == null)
            return Products.ToList();
        var q = from p in Products
                where filter(p)
                select p;
        return q.ToList();
    }
    public void Update(Product item)
    {
        var q = from p in Products
                where p?.ProductId == item.ProductId
                select p;
        Product prod = q.FirstOrDefault();
        if (prod == null)
            throw new ItemNotFoundException("product not found");
        Products.Remove(prod);
        Products.Add(item);

    }

    public void Delete(int id)
    {
        var q = from p in Products
                where p?.ProductId == id
                select p;
        Product prod = q.FirstOrDefault();
        if (prod == null)
            throw new ItemNotFoundException("product not found");

        Products.Remove(prod);

    }


}
// ...existing code...
