using Bussiness.Services;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billing.API.Controllers
{
    [ApiController]
    [Route("invoice")]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService _invoiceService)
        { this.invoiceService = _invoiceService; }

        [HttpGet("")]
        public IEnumerable<tInvoice> GetAllInvoices() => invoiceService.GetAll();

        [HttpGet("{id}")]
        public tInvoice GetInvoice(int id) => invoiceService.GetById(id);

        [HttpPost("")]
        [AllowAnonymous]
        public bool SaveInvoice(tInvoice invoice)
        {
            return invoiceService.Save(invoice);
        }
        [HttpDelete("{id}")]
        public bool DeleteInvoice(int id) => invoiceService.Delete(id);

        [HttpPost("Delete")]
        [AllowAnonymous]
        public bool DeleteInvoices(int[] ids)
        {
            return invoiceService.DeleteMulti(ids);
        }
    }
}
