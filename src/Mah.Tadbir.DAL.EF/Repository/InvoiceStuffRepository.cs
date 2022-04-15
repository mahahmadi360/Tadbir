using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mah.Tadbir.DAL.EF.Repository
{
    public class InvoiceStuffRepository:BaseRepository<InvoiceStuff>, IInvoiceStuffRepository
    {
        public InvoiceStuffRepository(DbContext dbContext):base(dbContext)
        {
            
        }
    }
}
