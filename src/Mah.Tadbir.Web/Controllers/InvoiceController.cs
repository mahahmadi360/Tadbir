using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.Services;
using Mah.Tadbir.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mah.Tadbir.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _InvoiceService;
        private readonly IMapper _Mapper;

        public InvoiceController(IInvoiceService invoiceService,
            IMapper mapper)
        {
            _InvoiceService = invoiceService;
            _Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<InvoiceModel>> Get()
        {
            var invoices = await _InvoiceService.GetAllInvoice();
            return invoices.Select(a => _Mapper.Map<InvoiceModel>(a));
        }

        [HttpGet("info")]
        public async Task<IEnumerable<InvoiceInfo>> GetInfo()
        {
            return await _InvoiceService.GetAllInvoiceInfo();
        }

        [HttpGet("{id:int}")]
        public async Task<InvoiceModel> Get(int id)
        {
            return _Mapper.Map<InvoiceModel>(
                await _InvoiceService.GetInvoiceById(id));
        }

        [HttpDelete("{id:int}")]
        public Task Delete(int id)
        {
            return _InvoiceService.Delete(new Invoice() { Id = id });
        }

        [HttpPut]
        public Task Put(InvoiceModel invoice)
        {
            return _InvoiceService.Update(_Mapper.Map<Invoice>(invoice));
        }

        [HttpPost]
        public Task Post(InvoiceModel invoice)
        {
            return _InvoiceService.Add(_Mapper.Map<Invoice>(invoice));
        }
    }
}
