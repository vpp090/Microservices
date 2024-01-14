using EcomWebApp.Contracts;
using EcomWebApp.Services;
using SpecMapperR.Extensions;

namespace EcomWebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSpecMapper();

            services.AddHttpClient<ICatalogService, CatalogService>(c =>
                c.BaseAddress = new Uri(config["ApiSettings:GatewayAddress"]));

            services.AddHttpClient<IBasketService, BasketService>(c =>
                c.BaseAddress = new Uri(config["ApiSettings:GatewayAddress"]));

            services.AddHttpClient<IOrderService, OrderService>(c =>
                c.BaseAddress = new Uri(config["ApiSettings:GatewayAddress"]));

            
            return services;
        }
    }
}
