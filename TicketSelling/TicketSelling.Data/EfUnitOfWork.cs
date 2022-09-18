using TicketSelling.Core;

namespace TicketSelling.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly TicketSellingContext _context;

        public EfUnitOfWork(TicketSellingContext context)
        {
            _context = context;
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
