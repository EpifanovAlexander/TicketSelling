using AutoMapper;
using TicketSelling.Controllers.Tickets.Dto;
using TicketSelling.Core.Domains.Passengers;
using TicketSelling.Core.Domains.Segments;
using TicketSelling.Core.Domains.Tickets;

namespace TicketSelling.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<PassengerDto, Passenger>();
            CreateMap<RefundTicketDto, RefundTicket>();
            CreateMap<SaleTicketDto, SaleTicket>();
            CreateMap<SegmentDto, Segment>();
        }
    }
}
