using AutoMapper;
using TicketSelling.Core.Domains.Segments.Repositories;
using TicketSelling.Core.Domains.Tickets.Dto;

namespace TicketSelling.Core.Domains.Tickets.Services
{
    public class TicketService : ITicketService
    {
        private readonly IMapper _mapper;
        private readonly ISegmentRepository _segmentRepository;

        public TicketService(IMapper mapper, ISegmentRepository segmentRepository)
        {
            _mapper = mapper;
            _segmentRepository = segmentRepository;
        }

        public async Task RefundTicketAsync(RefundTicketDto refundTicketDto, CancellationToken token)
        {
            await _segmentRepository.RefundSegmentsByTicketNumberAsync(refundTicketDto.TicketNumber, token);
        }

        public async Task SaleTicketAsync(SaleTicketDto saleTicketDto, CancellationToken token)
        {
            var saleTicket = _mapper.Map<SaleTicket>(saleTicketDto);
            await _segmentRepository.SaleTicketAsync(saleTicket, token);
        }
    }
}
