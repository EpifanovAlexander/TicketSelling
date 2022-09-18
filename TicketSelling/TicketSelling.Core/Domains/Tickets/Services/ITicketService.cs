using TicketSelling.Core.Domains.Tickets.Dto;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public interface ITicketService
    {
        Task SaleTicket(SaleTicketDto saleTicketDto, CancellationToken token);
        Task RefundTicket(RefundTicketDto refundTicketDto, CancellationToken token);
    }
}
