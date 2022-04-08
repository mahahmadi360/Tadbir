using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Mah.Tadbir.DAL.EF.Context
{
    class TadbirContextFactory : IDesignTimeDbContextFactory<TadbirContext>
    {
        public TadbirContext CreateDbContext(string[] args)
        {
            var dbPath = @"E:\Developing\Tadbir\Mah.Tadbir\src\Mah.Tadbir.Web\Tadbir.Db.mdf";

            var contextOptionBuilder = new DbContextOptionsBuilder<TadbirContext>()
             .UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True");
            return new TadbirContext(contextOptionBuilder.Options);
        }
    }
}
