using AutoMapper;
using TicketSelling.Core.Domains.Segments;
using TicketSelling.Data.DbModels.Segments;

namespace TicketSelling.Data.Mappers
{
    public class DbModelMappingProfile: Profile
    {
        public DbModelMappingProfile()
        {
            CreateMap<Segment, SegmentDbModel>();
        }
    }
}
