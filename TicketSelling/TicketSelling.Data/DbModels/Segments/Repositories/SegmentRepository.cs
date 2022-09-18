using TicketSelling.Core.Domains.Segments.Repositories;
using TicketSelling.Core.Domains.Tickets;

namespace TicketSelling.Data.DbModels.Segments.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        public Task RefundSegmentsByTicketNumber(string ticketNumber, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task SaleTicket(SaleTicket ticket, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
