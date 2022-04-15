using Ardalis.Specification;
using Mah.Tadbir.Entity;
using System.Linq;

namespace Mah.Tadbir.Interface.DAL.Repository
{
    public interface IInvoiceRepository:IBaseRepository<Invoice>
    {
        IQueryable<InvoiceInfo> GetInfoData(ISpecification<InvoiceInfo> specification);
    }
}
