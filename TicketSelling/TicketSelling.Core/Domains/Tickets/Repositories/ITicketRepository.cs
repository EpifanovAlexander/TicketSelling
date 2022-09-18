namespace TicketSelling.Core.Domains.Tickets.Repositories
{
    public interface ITicketRepository
    {
        void SaleTicket();
        void RefundTicket();
    }
}
