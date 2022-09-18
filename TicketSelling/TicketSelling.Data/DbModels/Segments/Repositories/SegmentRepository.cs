using AutoMapper;
using TicketSelling.Core.Domains.Segments.Repositories;
using TicketSelling.Core.Domains.Tickets;

namespace TicketSelling.Data.DbModels.Segments.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        private readonly IMapper _mapper;
        private readonly TicketSellingContext _context;
        public SegmentRepository(IMapper mapper, TicketSellingContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task RefundSegmentsByTicketNumber(string ticketNumber, CancellationToken token)
        {
            var segments = _context.Segments.Where(segment => segment.TicketNumber == ticketNumber).ToList();
            segments.ForEach(segment => segment.State = "refund");
            _context.Segments.UpdateRange(segments);
            return _context.SaveChangesAsync(token);
        }

        public Task SaleTicket(SaleTicket ticket, CancellationToken token)
        {
            int index = 1;
            foreach (var segment in ticket.Routes)
            {
                var segmentDbModel = _mapper.Map<SegmentDbModel>(segment);
                segmentDbModel.TicketNumber = ticket.Passenger.TicketNumber;
                segmentDbModel.SerialNumber = index++;
                segmentDbModel.State = "issued";
                _context.Segments.AddAsync(segmentDbModel);
            }
            return _context.SaveChangesAsync(token);
        }
    }
}
