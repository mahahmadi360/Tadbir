using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mah.Tadbir.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _InvoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _InvoiceService = invoiceService;
        }

        [HttpGet]
        public Task<IEnumerable<Invoice>> Get()
        {
            return _InvoiceService.GetAllInvoice();
        }

        [HttpGet("{id:int}")]
        public Task<Invoice> Get(int id)
        {
            return _InvoiceService.GetInvoiceById(id);
        }

        [HttpDelete("{id:int}")]
        public Task Delete(int id)
        {
             return _InvoiceService.Delete(new Invoice() { Id = id });
        }

        [HttpPut]
        public Task Put(Invoice invoice)
        {
            return _InvoiceService.Update(invoice);
        }

        [HttpPost]
        public Task Post(Invoice invoice)
        {
            return _InvoiceService.Add(invoice);
        }
    }
}
