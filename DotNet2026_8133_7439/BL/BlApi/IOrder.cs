
using BO;

namespace BlApi;

public interface IOrder
{
    List<SaleInProduct> AddProductToOrder(Order order, int productId, int count);
    void CalcTotalPriceForProduct(ProductInOrder productInOrder);
    void CalcTotalPrice(Order order);
    void DoOrder(Order order);
    void SearchSaleForProduct(ProductInOrder productInOrder, bool isPreferedCustomer);
   

}

