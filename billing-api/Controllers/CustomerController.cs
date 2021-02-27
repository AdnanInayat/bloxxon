using Billing.API.ViewModels;
using Bussiness.Services;
using Bussiness.ViewModels;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace Billing.API.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;
        private readonly IWebHostEnvironment env;
        public CustomerController(ICustomerService _customerService, IWebHostEnvironment _env)
        { 
            this.customerService = _customerService;
            env = _env;
        }

        [HttpGet("")]
        public IEnumerable<tCustomer> GetAllCustomers(string query) => customerService.GetAll();
        [HttpGet("search")]
        public IEnumerable<tCustomer> SearchCustomers(string query) 
        {
            query = string.IsNullOrEmpty(query) ? "" : query;
            return customerService.SearchCustomers(query);
        }
        [HttpGet("combo")]
        public IEnumerable<CustomerComboModel> GetCustomersForCombo() => customerService.GetCustomersForCombo();

        [HttpGet("{id}")]
        public tCustomer GetCustomer(int id) => customerService.GetById(id);

        [HttpPost("")]
        [AllowAnonymous]
        public bool SaveCustomer(CustomerViewModel customer)
        {
            customer.ImgUrl = UploadedFile(customer);
            tCustomer tc = new tCustomer
            {
                Id = customer.Id,
                Firstname = customer.Firstname,
                Lastname = customer.Lastname,
                Email = customer.Email,
                ImgUrl = customer.ImgUrl,
                Invoices = customer.Invoices
            };
            return customerService.SaveCustomer(tc);
        }
        [HttpDelete("{id}")]
        public bool DeleteCustomer(int id) => customerService.Delete(id);


        private string UploadedFile(CustomerViewModel model)
        {
            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(env.WebRootPath, "customerimages");
                string uniqueFileName = Guid.NewGuid().ToString();
                string ext = model.ImgUrl.Split('.')[model.ImgUrl.Split('.').Length - 1];
                uniqueFileName += $".{ext}";
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //filePath += $".{ext}";
                var base64string = model.ProfileImage.Split(',')[1];
                byte[] bytes = Convert.FromBase64String(base64string);

                System.IO.File.WriteAllBytes(filePath, bytes);

                return uniqueFileName;
            }
            return model.ImgUrl;
        }
    }
}
