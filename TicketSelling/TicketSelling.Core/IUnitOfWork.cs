using TicketSelling.Core.Domains.Segments.Repositories;

namespace TicketSelling.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISegmentRepository Segments { get; }
        Task SaveChanges();
    }
}
