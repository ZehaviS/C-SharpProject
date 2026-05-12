
namespace DO;

public record Product
(
    int ProductId,
    string ProductName,
    ProductsCategories ProductCategory,
    double ProductPrice,
    int ProductCount
)
{
public Product() : this(0, "", ProductsCategories.FUR_PASTRY, 0, 0) 
{ 
}


}
	


