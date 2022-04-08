using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.DAL;
using Mah.Tadbir.Interface.DAL.Repository;
using Mah.Tadbir.Interface.Services;
using Mah.Tadbir.Specification;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mah.Tadbir.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IInvoiceRepository _InvoiceRepository;

        public InvoiceService(IUnitOfWork unitOfWork, IInvoiceRepository invoiceRepository)
        {
            this._UnitOfWork = unitOfWork;
            this._InvoiceRepository = invoiceRepository;
        }
        public Task Add(Invoice entity)
        {
            _InvoiceRepository.Add(entity);
            return _UnitOfWork.SaveChangesAsync();
        }

        public Task Delete(params Invoice[] entities)
        {
            _InvoiceRepository.Delete(entities);
            return _UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoice()
        {
            return await _InvoiceRepository.GetData(new TrueSpecification<Invoice>()).ToListAsync();
        }

        public Task<Invoice> GetInvoiceById(int id)
        {
            return _InvoiceRepository.GetData(id);
        }

        public Task Update(Invoice entity)
        {
            _InvoiceRepository.Update(entity);
            return _UnitOfWork.SaveChangesAsync();
        }
    }
}
