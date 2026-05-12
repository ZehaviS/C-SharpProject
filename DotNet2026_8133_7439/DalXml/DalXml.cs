using DalApi;

namespace Dal;

internal sealed class DalXml : IDal
{
    public Isale sale => new ImplementationSale();
    public Iproduct product => new ImplementationProduct();
    public Icustomer customer => new ImplementationCustomer();

    private DalXml() { }

    private static readonly DalXml instance = new DalXml();
    public static DalXml Instance => instance;
}
