using Mah.Tadbir.DAL.EF.Context.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Mah.Tadbir.DAL.EF.Context
{
    public class TadbirContext : DbContext
    {
        public TadbirContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StuffEntityConfiguration());
        }
    }
}
