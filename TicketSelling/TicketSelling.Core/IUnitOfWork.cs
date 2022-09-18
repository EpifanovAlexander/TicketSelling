namespace TicketSelling.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChanges();
    }
}
