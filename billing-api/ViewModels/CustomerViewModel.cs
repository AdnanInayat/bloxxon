using Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public List<tInvoice> Invoices { get; set; }

        //base64 png as string data
        public string ProfileImage { get; set; }
    }
}
