using MediatR;
using TicketSelling.Core.Domains.Tickets.Services;

namespace TicketSelling.Core.Domains.Tickets.Commands.SaleTicketCommands
{
    public class SaleTicketCommandHandler : IRequestHandler<SaleTicketCommand, Unit>
    {
        private readonly ITicketService _ticketService;

        public SaleTicketCommandHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<Unit> Handle(SaleTicketCommand request, CancellationToken cancellationToken)
        {
            await _ticketService.SaleTicketAsync(request, cancellationToken);
            return Unit.Value;
        }
    }
}
