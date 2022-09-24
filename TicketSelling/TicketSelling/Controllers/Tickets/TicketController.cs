using Microsoft.AspNetCore.Mvc;
using TicketSelling.Core.Domains.Tickets.Dto;
using TicketSelling.Core.Domains.Tickets.Services;

namespace TicketSelling.Controllers.Tickets
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TicketController : ControllerBase
    {    
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("sale/")]
        public async Task Sale(SaleTicketDto saleTicketDto, CancellationToken cancellationToken)
        {
            await _ticketService.SaleTicketAsync(saleTicketDto, cancellationToken);
        }

        [HttpPost("refund/")]
        public async Task Refund(RefundTicketDto refundTicketDto, CancellationToken cancellationToken)
        {
            await _ticketService.RefundTicketAsync(refundTicketDto, cancellationToken);
        }
    }
}