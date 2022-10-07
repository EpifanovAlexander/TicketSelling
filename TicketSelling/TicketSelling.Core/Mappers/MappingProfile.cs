using AutoMapper;
using TicketSelling.Core.Domains.Passengers;
using TicketSelling.Core.Domains.Passengers.Dto;
using TicketSelling.Core.Domains.Segments;
using TicketSelling.Core.Domains.Segments.Dto;
using TicketSelling.Core.Domains.Tickets;
using TicketSelling.Core.Domains.Tickets.Commands.RefundTicketCommands;
using TicketSelling.Core.Domains.Tickets.Commands.SaleTicketCommands;

namespace TicketSelling.Core.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<PassengerDto, Passenger>();
            CreateMap<RefundTicketCommand, RefundTicket>();
            CreateMap<SaleTicketCommand, SaleTicket>();
            CreateMap<SegmentDto, Segment>();
        }
    }
}
