using AutoMapper;
using Mah.Tadbir.Entity;
using Mah.Tadbir.Web.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mah.Tadbir.Web.Config
{
    public static class MapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InvoiceStuff, InvoiceStuffModel>()
                   .ForMember(a => a.StuffName, b => b.MapFrom(c => c.Stuff.Name))
                   .ReverseMap();

                cfg.CreateMap<Invoice, InvoiceModel>().ReverseMap();
            });
        }

        public static IServiceCollection ConfigMapper(this IServiceCollection services)
        {
            var mapper = GetMapperConfiguration().CreateMapper();

            services.AddSingleton<IMapper>(mapper);

            return services;
        }
    }
}
