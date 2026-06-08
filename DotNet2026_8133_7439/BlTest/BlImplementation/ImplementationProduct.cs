using BlApi;
using BO;
using DalApi;
using DO;

namespace BlImplementation;

internal class ImplementationProduct : IProduct
{
    private readonly IDal _dal = DalApi.Factory.Get;
    // ================= CREATE =================
    public int Create(BO.Product item)
    {
        _dal.product.Create(new DO.Product
        {
            ProductId = item.ProductId,
            ProductName = item.ProductName,
            ProductPrice = item.ProductPrice,
            ProductCategory = (DO.ProductsCategories)(int)item.ProductCategory,
            ProductCount = item.ProductCount
        });

        return item.ProductId;
    }

    // ================= READ =================
    public BO.Product? Read(int id)
    {
        var p = _dal.product.Read(id);

        if (p == null) return null;

        return new BO.Product
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            ProductPrice = p.ProductPrice,
            ProductCategory = (BO.ProductsCategories)(int)p.ProductCategory,
            ProductCount = p.ProductCount
        };
    }

    // ================= READ BY FILTER =================
    public BO.Product? Read(Func<BO.Product, bool> filter)
    {
        return ReadAll(filter).FirstOrDefault();
    }

    // ================= READ ALL =================
    public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        var list = _dal.product.ReadAll();

        var result = list.Select(p => new BO.Product
        {
            ProductId = p.ProductId,
            ProductName = p.ProductName,
            ProductPrice = p.ProductPrice,
            ProductCategory = (BO.ProductsCategories)(int)p.ProductCategory,
            ProductCount = p.ProductCount
        }).ToList();

        if (filter != null)
            result = result.Where(filter).ToList();

        return result;
    }

    // ================= UPDATE =================
    public void Update(BO.Product item)
    {
        _dal.product.Update(new DO.Product
        {
            ProductId = item.ProductId,
            ProductName = item.ProductName,
            ProductPrice = item.ProductPrice,
            ProductCategory = (DO.ProductsCategories)(int)item.ProductCategory,
            ProductCount = item.ProductCount
        });
    }

    // ================= DELETE =================
    public void Delete(int id)
    {
        _dal.product.Delete(id);
    }

    // ================= SALES =================
    public List<BO.Product> GetAllSalesOfProduct(ProductInOrder productInOrder, bool isPreferedCustomer)
    {
        return new List<BO.Product>();
    }
}