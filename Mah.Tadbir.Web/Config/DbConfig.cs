using Mah.Tadbir.DAL.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Mah.Tadbir.Web.Config
{
    public static class DbConfig
    {
        public static void RegisterDb(this IServiceCollection services)
        {
            //E:\Developing\Tadbir\Mah.Tadbir\Mah.Tadbir.Web\Tadbir.Db.mdf
            var rootFolder = Directory.GetCurrentDirectory();
            var dbPath = Path.Combine(rootFolder, "Tadbir.Db.mdf");

            services.AddDbContext<TadbirContext>(a=>{
                new DbContextOptionsBuilder<TadbirContext>()
                .UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True");
            });
        }
    }
}
