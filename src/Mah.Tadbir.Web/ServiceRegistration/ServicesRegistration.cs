using Mah.Tadbir.Interface.Services;
using Mah.Tadbir.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Mah.Tadbir.Web.ServiceRegistration
{
    public static class ServicesRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStuffService, StuffService>();
            serviceCollection.AddScoped<IInvoiceService, InvoiceService>();
            return serviceCollection;
        }
    }
}
