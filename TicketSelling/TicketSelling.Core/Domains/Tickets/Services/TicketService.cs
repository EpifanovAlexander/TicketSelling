using AutoMapper;
using TicketSelling.Core.Domains.Tickets.Dto;

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

        public async Task RefundTicketAsync(RefundTicketDto refundTicketDto, CancellationToken token)
        {
            await _unitOfWork.Segments.RefundSegmentsByTicketNumberAsync(refundTicketDto.TicketNumber, token);
        }

        public async Task SaleTicketAsync(SaleTicketDto saleTicketDto, CancellationToken token)
        {
            var saleTicket = _mapper.Map<SaleTicket>(saleTicketDto);
            await _unitOfWork.Segments.SaleTicketAsync(saleTicket, token);
        }
    }
}
