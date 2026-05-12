using DalApi;
using DO;
using static Dal.DataSource;

namespace Dal;

internal class ImplementationCustomer : Icustomer
{

    public int Create(Customer customer)
    {
        var q = from c in Customers
                where c?.CustomerId == customer.CustomerId
                select c;
        Customer cust = q.FirstOrDefault();
        if (cust != null)
            throw new CustomerApperException("customer apper");
        Customers.Add(customer);
        return customer.CustomerId;
    }
    public Customer? Read(int id)
    {
        var q = from c in Customers
                where c?.CustomerId == id
                select c;
        Customer cust = q.FirstOrDefault();
        if (cust == null)
            throw new ItemNotFoundException("customer not found");

        return cust;
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        return Customers.FirstOrDefault(filter);
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        if (filter == null)
            return Customers.ToList();
        var q = from c in Customers
                where filter(c)
                select c;
        return q.ToList();
    }

    public void Update(Customer item)
    {
        var q = from c in Customers
                where c?.CustomerId == item.CustomerId
                select c;
        Customer cust = q.FirstOrDefault();
        if (cust == null)
            throw new ItemNotFoundException("customer not found");
        Customers.Remove(cust);
        Customers.Add(cust);

    }

    public void Delete(int id)
    {
        var q = from c in Customers
                where c?.CustomerId == id
                select c;
       Customer cust = q.FirstOrDefault();
        if (cust == null)
            throw new ItemNotFoundException("customer not found");

        Customers.Remove(cust);
    }

}
