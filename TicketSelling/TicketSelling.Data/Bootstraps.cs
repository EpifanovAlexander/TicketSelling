using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSelling.Core;
using TicketSelling.Core.Domains.Segments.Repositories;
using TicketSelling.Data.DbModels.Segments.Repositories;

namespace TicketSelling.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISegmentRepository, SegmentRepository>();

            services.AddScoped<IUnitOfWork, EfUnitOfWork>();

            services.AddDbContext<TicketSellingContext>(options => options
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("PostgreConnection")));

            return services;
        }
    }
}
