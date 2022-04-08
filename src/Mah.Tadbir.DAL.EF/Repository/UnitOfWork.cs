using Mah.Tadbir.Interface.DAL;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Mah.Tadbir.DAL.EF.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _DbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public Task SaveChangesAsync()
        {
            return _DbContext.SaveChangesAsync();
        }
    }
}
