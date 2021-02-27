using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public interface ICustomerRepo
    {
        public IEnumerable<tCustomer> GetAll();
        public IEnumerable<tCustomer> SearchCustomers(string query);
        public tCustomer GetById(int id);
        public bool Insert(tCustomer entity);
        public bool Update(tCustomer entity);
        public bool Delete(int id);
    }
    public class CustomerRepo : ICustomerRepo
    {
        protected readonly DatabaseContext context;
        public CustomerRepo(DatabaseContext context)
        {
            this.context = context;
        }
        public IEnumerable<tCustomer> GetAll()
        {
            return context.Customers.AsEnumerable();
        }
        public IEnumerable<tCustomer> SearchCustomers(string query)
        {
            return context.Customers.Where(o => o.Firstname.Contains(query) || o.Lastname.Contains(query) || o.Email.Contains(query)).AsEnumerable();
        }
        public tCustomer GetById(int id)
        {
            return context.Customers.Include(o => o.Invoices).SingleOrDefault(s => s.Id == id);
        }
        public bool Insert(tCustomer entity)
        {
            if (entity == null) return false;

            context.Customers.Add(entity);
            context.SaveChanges();
            return true;
        }
        public bool Update(tCustomer entity)
        {
            if (entity == null) return false;
            context.Customers.Update(entity);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            if (id <= 0) return false;

            tCustomer entity = context.Customers.Include(o => o.Invoices).SingleOrDefault(s => s.Id == id);
            if (entity != null && entity.Invoices.Count == 0)
            {
                context.Remove(entity);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
