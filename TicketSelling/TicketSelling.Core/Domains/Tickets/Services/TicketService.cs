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

        public Task RefundTicket(RefundTicketDto refundTicketDto, CancellationToken token)
        {
            return _segmentRepository.RefundSegmentsByTicketNumber(refundTicketDto.TicketNumber, token);
        }

        public Task SaleTicket(SaleTicketDto saleTicketDto, CancellationToken token)
        {
            var saleTicket = _mapper.Map<SaleTicket>(saleTicketDto);
            return _segmentRepository.SaleTicket(saleTicket, token);
        }
    }
}
