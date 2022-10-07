using TicketSelling.Core.Domains.Tickets.Commands.RefundTicketCommands;
using TicketSelling.Core.Domains.Tickets.Commands.SaleTicketCommands;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public interface ITicketService
    {
        Task SaleTicketAsync(SaleTicketCommand saleTicketDto, CancellationToken token);
        Task RefundTicketAsync(RefundTicketCommand refundTicketDto, CancellationToken token);
    }
}
