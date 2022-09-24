using TicketSelling.Core.Domains.Tickets.Dto;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public interface ITicketService
    {
        Task SaleTicketAsync(SaleTicketDto saleTicketDto, CancellationToken token);
        Task RefundTicketAsync(RefundTicketDto refundTicketDto, CancellationToken token);
    }
}
