using Bussiness.Extensions;
using Bussiness.ViewModels;
using Data.Models;
using Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Services
{
    public interface ICustomerService
    {
        public IEnumerable<tCustomer> GetAll();
        public IEnumerable<tCustomer> SearchCustomers(string query);
        public tCustomer GetById(int id);
        public IEnumerable<CustomerComboModel> GetCustomersForCombo();
        public bool SaveCustomer(tCustomer entity);
        //public bool Update(tCustomer entity);
        public bool Delete(int id);
    }
    public class CustomerService : ICustomerService
    {
        private ICustomerRepo customerRepo;
        public CustomerService(ICustomerRepo _customerRepo)
        {
            customerRepo = _customerRepo;
        }

        public IEnumerable<tCustomer> GetAll()
        {
            return customerRepo.GetAll();
        }
        public IEnumerable<tCustomer> SearchCustomers(string query)
        {
            return customerRepo.SearchCustomers(query);
        }

        public tCustomer GetById(int id)
        {
            return customerRepo.GetById(id);
        }

        public IEnumerable<CustomerComboModel> GetCustomersForCombo()
        {
            var customers = GetAll();
            return customers.Select(o => o.ToComboModel()).ToList();
        }

        public bool SaveCustomer(tCustomer entity)
        {
            if(entity.Id > 0)
            {
                return customerRepo.Update(entity);
            }
            return customerRepo.Insert(entity);
        }

        public bool Delete(int id)
        {
            return customerRepo.Delete(id);
        }


        //public bool Update(tCustomer entity)
        //{
        //    return customerRepo.Update(entity);
        //}
    }
}
