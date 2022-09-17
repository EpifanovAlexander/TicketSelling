using Microsoft.AspNetCore.Mvc;

namespace TicketSelling.Controllers.Tickets
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TicketController : ControllerBase
    {
        [HttpPost("sale/")]
        public void Sale()
        {
            
        }

        [HttpPost("refund/")]
        public void Refund()
        {
            
        }
    }
}