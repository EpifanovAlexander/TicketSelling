using TicketSelling.Core.Domains.Tickets;

namespace TicketSelling.Core.Domains.Segments.Repositories
{
    public interface ISegmentRepository
    {
        Task SaleTicket(SaleTicket ticket, CancellationToken token);
        Task RefundSegmentsByTicketNumber(string ticketNumber, CancellationToken token);
    }
}
