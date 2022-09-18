using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSelling.Core;
using TicketSelling.Core.Domains.Tickets.Repositories;
using TicketSelling.Data.DbModels.Tickets.Repositories;

namespace TicketSelling.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            services.AddDbContext<TicketSellingContext>(options => options
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("PostgreConnection")));

            return services;
        }
    }
}
