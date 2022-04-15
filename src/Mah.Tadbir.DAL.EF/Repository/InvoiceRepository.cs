using Ardalis.Specification;
using Mah.Tadbir.DAL.EF.Extensions;
using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mah.Tadbir.DAL.EF.Repository
{
    public class InvoiceRepository:BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext dbContext):base(dbContext)
        {

        }

        public IQueryable<InvoiceInfo> GetInfoData(ISpecification<InvoiceInfo> specification)
        {
            return _DbContext.Set< InvoiceInfo>().ApplySpecification(specification);
        }
    }
}
