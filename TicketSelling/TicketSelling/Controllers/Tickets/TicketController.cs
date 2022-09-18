using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketSelling.Controllers.Tickets.Dto;
using TicketSelling.Core.Domains.Tickets;
using TicketSelling.Core.Domains.Tickets.Services;

namespace TicketSelling.Controllers.Tickets
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TicketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;

        public TicketController(IMapper mapper, ITicketService ticketService)
        {
            _mapper = mapper;
            _ticketService = ticketService;
        }

        [HttpPost("sale/")]
        public async Task Sale(SaleTicketDto model, CancellationToken cancellationToken)
        {
            var saleTicket = _mapper.Map<SaleTicket>(model);
            await _ticketService.SaleTicket(saleTicket, cancellationToken);
        }

        [HttpPost("refund/")]
        public async Task Refund(RefundTicketDto model, CancellationToken cancellationToken)
        {
            var refundTicket = _mapper.Map<RefundTicket>(model);
            await _ticketService.RefundTicket(refundTicket, cancellationToken);
        }
    }
}