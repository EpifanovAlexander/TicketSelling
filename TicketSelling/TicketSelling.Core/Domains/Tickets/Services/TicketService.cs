using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSelling.Core.Domains.Tickets.Dto;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;

        public TicketService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task RefundTicket(RefundTicketDto refundTicketDto, CancellationToken token)
        {
            var refundTicket = _mapper.Map<RefundTicket>(refundTicketDto);
            throw new NotImplementedException();
        }

        public Task SaleTicket(SaleTicketDto saleTicketDto, CancellationToken token)
        {
            var saleTicket = _mapper.Map<SaleTicket>(saleTicketDto);
            throw new NotImplementedException();
        }
    }
}
