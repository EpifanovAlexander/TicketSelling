using Microsoft.AspNetCore.Mvc;
using TicketSelling.Controllers.Tickets.Dto;

namespace TicketSelling.Controllers.Tickets
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TicketController : ControllerBase
    {
        [HttpPost("sale/")]
        public void Sale(SaleTicketDto model)
        {
            
        }

        [HttpPost("refund/")]
        public void Refund(RefundTicketDto model)
        {
            
        }
    }
}