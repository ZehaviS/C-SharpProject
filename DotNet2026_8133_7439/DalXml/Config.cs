using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        private static readonly string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "xml", "data-config.xml");
        private static readonly XElement dataConfig = LoadConfig();

        private static XElement LoadConfig()
        {
            string? directory = Path.GetDirectoryName(fileName);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(fileName))
            {
                var defaultConfig = new XElement("config",
                    new XElement("ProductNum", 1000),
                    new XElement("SaleNum", 1));
                defaultConfig.Save(fileName);
                return defaultConfig;
            }

            using var stream = File.OpenRead(fileName);
            return XElement.Load(stream);
        }

        private static int productId;

        public static int GetProductId
        {
            get
            {
                int currentProId = int.Parse(dataConfig.Element("ProductNum").Value);
                dataConfig.Element("ProductNum").SetValue((currentProId + 1).ToString());
                dataConfig.Save(fileName);
                return currentProId;
            }
        }


        private static int saleId;

        public static int GetSaleId
        {
            get
            {
                int currentSaleId = int.Parse(dataConfig.Element("SaleNum").Value);
                dataConfig.Element("SaleNum").SetValue((currentSaleId + 1).ToString());
                dataConfig.Save(fileName);
                return currentSaleId;
            }


        }
    }
}
