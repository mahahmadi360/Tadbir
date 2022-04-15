using Mah.Tadbir.DAL.EF.Repository;
using Mah.Tadbir.Interface.DAL;
using Mah.Tadbir.Interface.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Mah.Tadbir.Web.ServiceRegistration
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IStuffRepository, StuffRepository>();
            serviceCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();
            serviceCollection.AddScoped<IInvoiceStuffRepository, InvoiceStuffRepository>();
            return serviceCollection;
        }
    }
}
