using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mah.Tadbir.DAL.EF.Repository
{
    public class InvoiceRepository:BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext dbContext):base(dbContext)
        {

        }
    }
}
