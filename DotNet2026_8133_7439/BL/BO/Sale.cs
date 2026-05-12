
namespace BO;

public class Sale
{
    public int SaleId { get; init; }
    public int ProductId { get; set; }
    public int ProductsCountToSale { get; set; }
    public double PriceAfterSale { get; set; }
    public bool OnlyClubCustomers { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd{ get; set; }
}

