using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public interface IInvoiceRepo
    {
        public IEnumerable<tInvoice> GetAll();
        public tInvoice GetById(int id);
        public bool Insert(tInvoice entity);
        public bool Update(tInvoice entity);
        public bool Delete(int id);
        public bool DeleteMulti(int[] ids);
    }
    public class InvoiceRepo : IInvoiceRepo
    {
        protected readonly DatabaseContext context;
        public InvoiceRepo(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<tInvoice> GetAll()
        {
            return context.Invoices.Include(o => o.Customer).AsEnumerable();
        }
        public tInvoice GetById(int id)
        {
            return context.Invoices.Include(o => o.Customer).SingleOrDefault(s => s.Id == id);
        }
        public bool Insert(tInvoice entity)
        {
            if (entity == null) return false;
            context.Invoices.Add(entity);
            context.SaveChanges();
            return true;
        }
        public bool Update(tInvoice entity)
        {
            if (entity == null) return false;
            context.Invoices.Update(entity);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            if (id <= 0) return false;

            tInvoice entity = context.Invoices.SingleOrDefault(s => s.Id == id);
            if(entity != null)
            {
                context.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteMulti(int[] ids)
        {
            List<tInvoice> entities = context.Invoices.Where(o => ids.Contains(o.Id)).ToList();
            if (entities != null)
            {
                context.RemoveRange(entities);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
