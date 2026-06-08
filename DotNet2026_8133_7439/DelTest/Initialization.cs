using DalApi;
using DalApi;
using DO;
namespace DalTest;

public static class Initialization
{
    private static IDal s_dal;
    public static void Initialize()
    {
        s_dal= DalApi.Factory.Get;
        // Run initialization but tolerate duplicates so initialization is idempotent
        try { createCustomers(); } catch { /* ignore duplicates or init errors */ }
        try { createProducts(); } catch { /* ignore duplicates or init errors */ }
        try { createSales(); } catch { /* ignore duplicates or init errors */ }
    }
    private static void createSales()
    {
        try { s_dal.sale.Create(new Sale(1, 1, 20, 3.5, 10, true, DateTime.Now, DateTime.Now.AddMonths(1))); } catch { }
        try { s_dal.sale.Create(new Sale(2, 2, 15, 2.5, 15, false, DateTime.Now, DateTime.Now.AddMonths(1))); } catch { }
        try { s_dal.sale.Create(new Sale(3, 3, 10, 4.0, 20, true, DateTime.Now, DateTime.Now.AddMonths(1))); } catch { }
        try { s_dal.sale.Create(new Sale(4, 4, 5, 35.0, 5, false, DateTime.Now, DateTime.Now.AddMonths(1))); } catch { }
        try { s_dal.sale.Create(new Sale(5, 5, 12, 6.0, 25, false, DateTime.Now, DateTime.Now.AddMonths(1))); } catch { }
    }
    private static void createProducts()
    {
        try { s_dal.product.Create(new Product(1, "Sourdough Loaf", ProductsCategories.BREADS, 18, 80)); } catch { }
        try { s_dal.product.Create(new Product(2, "Chocolate Croissant", ProductsCategories.DIARY_PASTRY, 10, 120)); } catch { }
        try { s_dal.product.Create(new Product(3, "Raisin Brioche", ProductsCategories.FUR_PASTRY, 12, 60)); } catch { }
        try { s_dal.product.Create(new Product(4, "Vanilla Cheesecake", ProductsCategories.SHOWCASE_CAKES, 160, 10)); } catch { }
        try { s_dal.product.Create(new Product(5, "Cafe Latte", ProductsCategories.DRINKS, 14, 100)); } catch { }

    }
    private static void createCustomers()
    {
        try { s_dal.customer.Create(new Customer(329427439,"Tovi Zak","Netivot Hamishpat 89","0527189210")); } catch { }
        try { s_dal.customer.Create(new Customer(328328133, "Zehavi Sabo", "Netivot Shalom 10", "0556758544")); } catch { }

    }
}
