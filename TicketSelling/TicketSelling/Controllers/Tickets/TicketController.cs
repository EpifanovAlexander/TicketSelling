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
        private const int REQUEST_TIMEOUT = 120 * 1000;

        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        private async Task Timeout()
        {
            await Task.Delay(REQUEST_TIMEOUT);
        }

        private async Task RunWithTimeout<T>(Func<T, CancellationToken, Task> ticketAsyncOperation, T ticketDto, CancellationToken cancellationToken) where T : class
        {
            var work = ticketAsyncOperation.Invoke(ticketDto, cancellationToken);
            var timeout = Timeout();
            var finishedTask = await Task.WhenAny(timeout, work);
            if (finishedTask == timeout)
            {
                cancellationToken.ThrowIfCancellationRequested();
                throw new TimeoutException();
            }
            else 
            {
                if (finishedTask.Exception != null && finishedTask.Exception.InnerException != null)
                    throw finishedTask.Exception.InnerException;
            }
        }

        [HttpPost("sale/")]
        public async Task Sale(SaleTicketDto saleTicketDto, CancellationToken cancellationToken)
        {
            await RunWithTimeout(_ticketService.SaleTicketAsync, saleTicketDto, cancellationToken);
        }

        [HttpPost("refund/")]
        public async Task Refund(RefundTicketDto refundTicketDto, CancellationToken cancellationToken)
        {
            await RunWithTimeout(_ticketService.RefundTicketAsync, refundTicketDto, cancellationToken);
        }
    }
}