using System.Collections;
using System.Collections.Generic;
using DO;

namespace BO;

static internal class Tools
{

    public static string ToStringProperty<T>(this T obj)
    {
        if (obj == null) return string.Empty;
        var properties = typeof(T).GetProperties();
        var result = new System.Text.StringBuilder();
        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj, null);
            if (value is IEnumerable enumerableValue && !(value is string)) // אם הערך הוא אוסף (ואינו מחרוזת)
            {
                result.AppendLine($"{prop.Name}: [");
                foreach (var item in enumerableValue)
                {
                    result.AppendLine($"  - {item}"); // מוסיפים כל איבר באוסף עם רווח לפני
                }
                result.AppendLine($"]");
            }
            else
            {
                result.AppendLine($"{prop.Name}: {value}");
            }
        }
        return result.ToString();
    }
    public static BO.Product ToBO(this DO.Product doObject)
    {
        return new BO.Product
        {
            ProductId = doObject.ProductId,
            ProductName = doObject.ProductName,
            ProductCategory = (BO.ProductsCategories)doObject.ProductCategory,
            ProductPrice = doObject.ProductPrice,
            ProductCount = doObject.ProductCount
        };

    }
    public static BO.Sale ToBO(this DO.Sale doObject)
    {
        return new BO.Sale
        {
            SaleId = doObject.SaleId,
            ProductId = doObject.ProductId,
            ProductsCountToSale = doObject.ProductsCountToSale,
            PriceAfterSale = doObject.PriceAfterSale,
            OnlyClubCustomers = doObject.OnlyClubCustomers,
            DateStart = doObject.DateStart,
            DateEnd = doObject.DateEnd
        };

    }
    public static BO.Customer ToBO(this DO.Customer doObject)
    {
        return new BO.Customer
        {
            CustomerId = doObject.CustomerId,
            CustomerName = doObject.CustomerName,
            CustomerAddress = doObject.CustomerAddress,
            CustomerPhone = doObject.CustomerPhone
        };

    }
    public static DO.Product ToDO(this BO.Product boObject)
    {
        return new DO.Product
        {
            ProductId = boObject.ProductId,
            ProductName = boObject.ProductName,
            ProductCategory = (DO.ProductsCategories)boObject.ProductCategory,
            ProductPrice = boObject.ProductPrice,
            ProductCount = boObject.ProductCount
        };

    }
    public static DO.Sale ToDO(this BO.Sale boObject)
    {
        return new DO.Sale
        {
            SaleId = boObject.SaleId,
            ProductId = boObject.ProductId,
            ProductsCountToSale = boObject.ProductsCountToSale,
            PriceAfterSale = boObject.PriceAfterSale,
            OnlyClubCustomers = boObject.OnlyClubCustomers,
            DateStart = boObject.DateStart,
            DateEnd = boObject.DateEnd
        };
        

    }
    public static DO.Customer ToDO(this BO.Customer boObject)
    {
        return new DO.Customer
        {
            CustomerId = boObject.CustomerId,
            CustomerName = boObject.CustomerName,
            CustomerAddress = boObject.CustomerAddress,
            CustomerPhone = boObject.CustomerPhone
        };
       

    }
}