using MediatR;
using TicketSelling.Core.Domains.Tickets.Services;

namespace TicketSelling.Core.Domains.Tickets.Commands.RefundTicketCommands
{
    public class RefundTicketCommandHandler : IRequestHandler<RefundTicketCommand, Unit>
    {
        private readonly ITicketService _ticketService;

        public RefundTicketCommandHandler(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<Unit> Handle(RefundTicketCommand request, CancellationToken cancellationToken)
        {
            await _ticketService.RefundTicketAsync(request, cancellationToken);
            return Unit.Value;
        }
    }
}
