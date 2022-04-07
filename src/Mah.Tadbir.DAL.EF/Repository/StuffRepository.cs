using Mah.Tadbir.Entity;
using Mah.Tadbir.Interface.DAL.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mah.Tadbir.DAL.EF.Repository
{
    public class StuffRepository : BaseRepository<Stuff>, IStuffRepository
    {
        public StuffRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
