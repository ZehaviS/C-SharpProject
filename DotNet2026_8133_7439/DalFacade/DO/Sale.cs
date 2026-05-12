

namespace DO;

public record Sale
(   int SaleId,
    int ProductId,
    int ProductsCountToSale,
    double PriceAfterSale,
    bool OnlyClubCustomers,
    DateTime? DateStart,
    DateTime? DateEnd

)

{
    public Sale() : this(0, 0,1,0,false,DateTime.Now,DateTime.Now)
    {

    }
}