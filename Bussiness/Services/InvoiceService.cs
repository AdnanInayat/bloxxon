using Data.Models;
using Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Services
{
    public interface IInvoiceService
    {
        public IEnumerable<tInvoice> GetAll();
        public tInvoice GetById(int id);
        public bool Save(tInvoice entity);
        public bool Delete(int id);
        public bool DeleteMulti(int[] ids);
    }
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceRepo invoiceRepo;
        public InvoiceService(IInvoiceRepo _invoiceRepo)
        {
            invoiceRepo = _invoiceRepo;
        }
        public IEnumerable<tInvoice> GetAll()
        {
            return invoiceRepo.GetAll();
        }

        public tInvoice GetById(int id)
        {
            return invoiceRepo.GetById(id);
        }

        public bool Save(tInvoice entity)
        {
            // hard coded value for possibility of authoriazation module
            entity.Customer = null;
            entity.UserId = 1;
            if(entity.Id > 0)
                return invoiceRepo.Update(entity);
            return invoiceRepo.Insert(entity);
        }
        public bool Delete(int id)
        {
            return invoiceRepo.Delete(id);
        }
        public bool DeleteMulti(int[] ids)
        {
            return invoiceRepo.DeleteMulti(ids);
        }
    }
}
