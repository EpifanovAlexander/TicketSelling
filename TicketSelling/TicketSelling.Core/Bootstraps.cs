using Microsoft.Extensions.DependencyInjection;
using TicketSelling.Core.Domains.Tickets.Services;

namespace TicketSelling.Core
{
    public static class Bootstraps
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<ITicketService, TicketService>();
            return services;
        }
    }
}
