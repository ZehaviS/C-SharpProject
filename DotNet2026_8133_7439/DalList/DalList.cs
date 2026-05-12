using System;
using DalApi;

namespace Dal
{
    sealed internal class DalList : IDal
    {
        public Isale sale => new ImplementationSale();
        public Iproduct product => new ImplementationProduct();
        public Icustomer customer => new ImplementationCustomer();

        
        private DalList()
        {
        }
        //ggggg
        private static readonly DalList instance = new DalList();

        public static DalList Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
