using BlApi;

namespace BlImplementation;

internal class Bl : IBl
{
    public IProduct Product => new ImplementationProduct();
    public ICustomer Customer => new ImplementationCustomer();
    public ISale Sale => new ImplementationSale();
    public IOrder Order => new ImplementationOrder();
}
