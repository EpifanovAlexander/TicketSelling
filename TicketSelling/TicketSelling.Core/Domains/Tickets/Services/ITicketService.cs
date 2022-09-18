namespace TicketSelling.Core.Domains.Tickets.Services
{
    public interface ITicketService
    {
        Task SaleTicket(SaleTicket saleTicket, CancellationToken token);
        Task RefundTicket(RefundTicket refundTicket, CancellationToken token);
    }
}
