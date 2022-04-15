using Mah.Tadbir.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mah.Tadbir.Interface.Services
{
    public interface IInvoiceService
    {
        Task Add(Invoice entity);
        Task Update(Invoice entity);
        Task Delete(params Invoice[] entities);

        Task<IEnumerable<Invoice>> GetAllInvoice();

        Task<IEnumerable<InvoiceInfo>> GetAllInvoiceInfo();
        Task<Invoice> GetInvoiceById(int id);
    }
}
