using Ardalis.GuardClauses;
using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.DAL;
using Mah.Tadbir.Interface.DAL.Repository;
using Mah.Tadbir.Interface.Services;
using Mah.Tadbir.Specification;
using Mah.Tadbir.Specification.Invoices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mah.Tadbir.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IInvoiceRepository _InvoiceRepository;
        private readonly IInvoiceStuffRepository _InvoiceStuffRepository;

        public InvoiceService(IUnitOfWork unitOfWork,
            IInvoiceRepository invoiceRepository,
            IInvoiceStuffRepository invoiceStuffRepository)
        {
            this._UnitOfWork = unitOfWork;
            this._InvoiceRepository = invoiceRepository;
            this._InvoiceStuffRepository = invoiceStuffRepository;
        }
        public Task Add(Invoice entity)
        {
            Guard.Against.Null(entity.InvoiceStuffs, nameof(entity.InvoiceStuffs));
            Guard.Against.Zero(entity.InvoiceStuffs.Count(), nameof(entity.InvoiceStuffs));

            foreach (var invoiceStuff
                in entity.InvoiceStuffs)
            {
                invoiceStuff.Stuff = null;
            }

            entity.RegisterDate = DateTime.Now;
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

        public async Task<IEnumerable<InvoiceInfo>> GetAllInvoiceInfo()
        {
            return await _InvoiceRepository.GetInfoData(new TrueSpecification<InvoiceInfo>()).ToListAsync();
        }

        public Task<Invoice> GetInvoiceById(int id)
        {
            return _InvoiceRepository.GetData(new InvoiceByIdIncludeStuffs(id))
                .FirstAsync();
        }

        public async Task Update(Invoice entity)
        {
            Guard.Against.Null(entity.InvoiceStuffs, nameof(entity.InvoiceStuffs));
            Guard.Against.Zero(entity.InvoiceStuffs.Count(), nameof(entity.InvoiceStuffs));

            foreach (var invoiceStuff
                in entity.InvoiceStuffs)
            {
                invoiceStuff.Stuff = null;
                if (invoiceStuff.Id > 0)
                    _InvoiceStuffRepository.Update(invoiceStuff);
            }


            var notUsedInvoices = await _InvoiceStuffRepository.GetData(
                 new InvoiceStuffByInvoiceIdAndIdNotInRange(entity.Id,
                 entity.InvoiceStuffs.Select(a => a.Id)
                 )).ToArrayAsync();

            if (notUsedInvoices.Any())
                _InvoiceStuffRepository.Delete(notUsedInvoices);

            entity.RegisterDate = DateTime.Now;
            _InvoiceRepository.Update(entity);
            await _UnitOfWork.SaveChangesAsync();

        }
    }
}
