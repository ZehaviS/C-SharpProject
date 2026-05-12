
using System.Linq;
using DalApi;
using BlApi;
using BO;
using DO;

namespace BlImplementation;

internal class ImplementationCustomer : ICustomer
{
    private void ValidateCustomer(BO.Customer c)
    {
        if (c.CustomerId <= 0)
            throw new Exception("Invalid ID");

        if (c.CustomerId.ToString().Length != 9)
            throw new Exception("ID must be 9 digits");

        if (string.IsNullOrWhiteSpace(c.CustomerName))
            throw new Exception("Name is required");

        if (string.IsNullOrWhiteSpace(c.CustomerPhone))
            throw new Exception("Phone is required");
    }
    private readonly IDal _dal = DalApi.Factory.Get;

    private static BO.Customer? FromDO(DO.Customer? d)
    {
        if (d == null) return null;
        return new BO.Customer
        {
            CustomerId = d.CustomerId,
            CustomerName = d.CustomerName,
            CustomerAddress = d.CustomerAddress,
            CustomerPhone = d.CustomerPhone
        };
    }

    private static DO.Customer ToDO(BO.Customer b)
    {
        return new DO.Customer(b.CustomerId, b.CustomerName, b.CustomerAddress ?? string.Empty, b.CustomerPhone);
    }

    public int Create(BO.Customer item)
    {
        ValidateCustomer(item);

        if (IsCustomerExist(item.CustomerId))
            throw new Exception("Customer already exists");

        var d = ToDO(item);
        return _dal.customer.Create(d);
    }

    public BO.Customer? Read(int id)
    {
        try
        {
            var d = _dal.customer.Read(id);
            return FromDO(d);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public BO.Customer? Read(Func<BO.Customer, bool> filter)
    {
        try
        {
            var list = _dal.customer.ReadAll();
            var mapped = list.Select(FromDO).Where(c => c != null).Select(c => c!).ToList();
            return mapped.FirstOrDefault(filter);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        try
        {
            var list = _dal.customer.ReadAll();
            var mapped = list.Select(FromDO).ToList();
            if (filter == null) return mapped;
            return mapped.Where(c => c != null && filter(c!)).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(BO.Customer item)
    {
        try
        {
            var d = ToDO(item);
            _dal.customer.Update(d);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(int id)
    {
        try
        {
            _dal.customer.Delete(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool IsCustomerExist(int id)
    {
        try
        {
            var list = _dal.customer.ReadAll();
            return list.Any(c => c?.CustomerId == id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
