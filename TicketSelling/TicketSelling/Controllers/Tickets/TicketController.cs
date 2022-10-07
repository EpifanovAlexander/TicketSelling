using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicketSelling.Core.Domains.Tickets.Commands.RefundTicketCommands;
using TicketSelling.Core.Domains.Tickets.Commands.SaleTicketCommands;

namespace TicketSelling.Controllers.Tickets
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TicketController : ControllerBase
    {
        private const int REQUEST_TIMEOUT = 120 * 1000;

        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task Sale([FromBody] SaleTicketCommand saleTicketCommand, CancellationToken cancellationToken)
        {
            await RunWithTimeout(_mediator.Send, saleTicketCommand, cancellationToken);
        }

        [HttpPost("refund/")]
        public async Task Refund([FromBody] RefundTicketCommand refundTicketCommand, CancellationToken cancellationToken)
        {
            await RunWithTimeout(_mediator.Send, refundTicketCommand, cancellationToken);
        }
    }
}