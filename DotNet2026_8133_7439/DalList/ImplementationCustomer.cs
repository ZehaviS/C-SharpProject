using System.Linq;
using System.Reflection;
using DalApi;
using DO;
using Tools;
using static Dal.DataSource;

namespace Dal;

internal class ImplementationCustomer : Icustomer
{
    public int Create(Customer customer)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Create customer id {customer.CustomerId}");
        var q = from c in Customers
                where c?.CustomerId == customer.CustomerId
                select c;
        Customer cust = q.FirstOrDefault();
        if (cust != null)
            throw new CustomerApperException("customer apper");
        Customers.Add(customer);
        LogManager.LogMessage(projectName, funcName, $"Created customer id {customer.CustomerId}");
        return customer.CustomerId;
    }
    public Customer? Read(int id)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Read customer id {id}");
        var q = from c in Customers
                where c?.CustomerId == id
                select c;
        Customer cust = q.FirstOrDefault();
        if (cust == null)
            throw new ItemNotFoundException("customer not found");

        LogManager.LogMessage(projectName, funcName, $"Read customer id {id}");
        return cust;
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, "Start Read customer by filter");
        var result = Customers.FirstOrDefault(filter);
        LogManager.LogMessage(projectName, funcName, result == null ? "Read customer with filter returned null" : $"Read customer id {result.CustomerId}");
        return result;
    }

    public List<Customer> ReadAll(Func<Customer, bool>? filter = null)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, "Start ReadAll customers");
        List<Customer> result;
        if (filter == null)
            result = Customers.ToList();
        else
        {
            var q = from c in Customers
                    where filter(c)
                    select c;
            result = q.ToList();
        }

        LogManager.LogMessage(projectName, funcName, $"Read all customers count {result.Count}");
        return result;
    }

    public void Update(Customer item)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Update customer id {item.CustomerId}");
        var q = from c in Customers
                where c?.CustomerId == item.CustomerId
                select c;
        Customer cust = q.FirstOrDefault();
        if (cust == null)
            throw new ItemNotFoundException("customer not found");
        Customers.Remove(cust);
        Customers.Add(item);
        LogManager.LogMessage(projectName, funcName, $"Updated customer id {item.CustomerId}");
    }

    public void Delete(int id)
    {
        var method = MethodBase.GetCurrentMethod()!;
        string projectName = method.DeclaringType?.FullName ?? "DalList";
        string funcName = method.Name;

        LogManager.LogMessage(projectName, funcName, $"Start Delete customer id {id}");
        var q = from c in Customers
                where c?.CustomerId == id
                select c;
       Customer cust = q.FirstOrDefault();
        if (cust == null)
            throw new ItemNotFoundException("customer not found");

        Customers.Remove(cust);
        LogManager.LogMessage(projectName, funcName, $"Deleted customer id {id}");
    }

}
