using AutoMapper;
using TicketSelling.Core.Domains.Tickets.Commands.RefundTicketCommands;
using TicketSelling.Core.Domains.Tickets.Commands.SaleTicketCommands;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task RefundTicketAsync(RefundTicketCommand refundTicketCommand, CancellationToken token)
        {
            await _unitOfWork.Segments.RefundSegmentsByTicketNumberAsync(refundTicketCommand.TicketNumber, token);
        }

        public async Task SaleTicketAsync(SaleTicketCommand saleTicketCommand, CancellationToken token)
        {
            var saleTicket = _mapper.Map<SaleTicket>(saleTicketCommand);
            await _unitOfWork.Segments.SaleTicketAsync(saleTicket, token);
        }
    }
}
