using Mah.Tadbir.DAL.EF.Context.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Mah.Tadbir.DAL.EF.Context
{
    public class TadbirContext : DbContext
    {
        public TadbirContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StuffEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceStuffsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceEntityConfiguration());

            modelBuilder.ApplyConfiguration(new InvoiceInfoEntityConfiguration());

        }
    }
}
