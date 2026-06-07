using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    sealed internal class DalXml : IDal
    {
        private DalXml() { }

        private static readonly DalXml instance = new DalXml();

        public static DalXml Instance
        {
            get { return instance; }
        }

        public Isale sale => new SaleImplementation();

        public Iproduct product => new ProductImplementation();

        public Icustomer customer => new CustomerImplementation();
    }
    

    }
