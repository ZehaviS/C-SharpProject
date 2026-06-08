

//using DalApi;
//using BlApi;
//using BO;

//namespace BlImplementation;

//internal class ImplementationSale : ISale
//{
//    private readonly IDal _dal = DalApi.Factory.Get;

//    public int Create(Sale item) => throw new NotImplementedException();
//    public Sale? Read(int id) => throw new NotImplementedException();
//    public Sale? Read(Func<Sale, bool> filter) => throw new NotImplementedException();
//    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null) => throw new NotImplementedException();
//    public void Update(Sale item) => throw new NotImplementedException();
//    public void Delete(int id) => throw new NotImplementedException();
//}
using BlApi;
using BO;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    internal class ImplementationSale : ISale
    {
        private readonly IDal _dal = DalApi.Factory.Get;

        // ================= MAPPERS =================
        private static BO.Sale FromDO(DO.Sale d) => new BO.Sale
        {
            SaleId = d.SaleId,
            ProductId = d.ProductId,
            ProductsCountToSale = d.ProductsCountToSale,
            PriceAfterSale = d.PriceAfterSale,
            Discount = d.Discount,
            OnlyClubCustomers = d.OnlyClubCustomers,
            DateStart = d.DateStart,
            DateEnd = d.DateEnd
        };

        private static DO.Sale ToDO(BO.Sale b) => new DO.Sale(
            b.SaleId,
            b.ProductId,
            b.ProductsCountToSale,
            b.PriceAfterSale,
            b.Discount,
            b.OnlyClubCustomers,
            b.DateStart,
            b.DateEnd
        );

        // ================= CREATE =================
        public int Create(BO.Sale item)
        {
            try
            {
                var d = ToDO(item);
                return _dal.sale.Create(d);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ================= READ BY ID =================
        public BO.Sale? Read(int id)
        {
            try
            {
                var d = _dal.sale.Read(id);
                return d == null ? null : FromDO(d);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ================= READ BY FILTER =================
        public BO.Sale? Read(Func<BO.Sale, bool> filter)
        {
            try
            {
                return ReadAll(filter).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ================= READ ALL =================
        public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
        {
            try
            {
                var list = _dal.sale.ReadAll()
                    .Select(d => (BO.Sale?)FromDO(d))
                    .ToList();

                if (filter == null)
                    return list;

                return list.Where(s => s != null && filter(s)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ================= UPDATE =================
        public void Update(BO.Sale item)
        {
            try
            {
                var d = ToDO(item);
                _dal.sale.Update(d);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ================= DELETE =================
        public void Delete(int id)
        {
            try
            {
                _dal.sale.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}