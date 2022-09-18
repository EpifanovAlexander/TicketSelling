using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public interface ITicketService
    {
        void SaleTicket();
        void RefundTicket();
    }
}
