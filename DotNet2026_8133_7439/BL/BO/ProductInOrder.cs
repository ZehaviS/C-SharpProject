
namespace BO;

public class ProductInOrder
{
    public int ProductId { get; set; } = 0;
    public string ProductName { get; set; } = string.Empty;
    public double BasePrice { get; set; } = 0;
    public int Count { get; set; } = 0;
    public List<SaleInProduct>? Sales { get; set; } = new List<SaleInProduct>();
    public double FinalPrice { get; set; } = 0;

}
