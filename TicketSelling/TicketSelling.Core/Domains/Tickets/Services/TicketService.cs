using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public class TicketService : ITicketService
    {
        public Task RefundTicket(RefundTicket refundTicket, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task SaleTicket(SaleTicket saleTicket, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
