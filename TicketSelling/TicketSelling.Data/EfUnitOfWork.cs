using TicketSelling.Core;
using TicketSelling.Core.Domains.Segments.Repositories;

namespace TicketSelling.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly TicketSellingContext _context;
        public ISegmentRepository Segments { get; }

        public EfUnitOfWork(TicketSellingContext context, ISegmentRepository segmentsRepository)
        {
            _context = context;
            Segments = segmentsRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
