using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketSelling.Core.Domains.Tickets.Services;

namespace TicketSelling.Core
{
    public static class Bootstraps
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ITicketService, TicketService>();
            return services;
        }
    }
}
