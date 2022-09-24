using TicketSelling.Core.Domains.Tickets;

namespace TicketSelling.Core.Domains.Segments.Repositories
{
    public interface ISegmentRepository
    {
        Task SaleTicketAsync(SaleTicket ticket, CancellationToken token);
        Task RefundSegmentsByTicketNumberAsync(string ticketNumber, CancellationToken token);
    }
}
