using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using TicketSelling.Core.Domains.Segments.Repositories;
using TicketSelling.Core.Domains.Tickets;

namespace TicketSelling.Data.DbModels.Segments.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        private const string SET_REFUND_STATE_QUERY = "UPDATE segments SET state = 'refund' WHERE ticket_number = {0} AND state <> 'refund';";
        private const string BEGIN_TRAN_QUERY = "BEGIN TRANSACTION;";
        private const string ROLLBACK_TRAN_QUERY = "ROLLBACK TRANSACTION;";
        private const string COMMIT_TRAN_QUERY = "COMMIT TRANSACTION;";
        private const string INSERT_INTO_SEGMENTS_QUERY = @"INSERT INTO segments (ticket_number, serial_number, airline_code, 
flight_number, depart_place, depart_datetime, depart_datetime_timezone, arrive_place, 
arrive_datetime, arrive_datetime_timezone, pnr_id, state)
VALUES({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, 'issued');";

        private readonly IMapper _mapper;
        private readonly TicketSellingContext _context;
        public SegmentRepository(IMapper mapper, TicketSellingContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task RefundSegmentsByTicketNumber(string ticketNumber, CancellationToken token)
        {
            int rowsAffected = _context.Database.ExecuteSqlRaw(SET_REFUND_STATE_QUERY, ticketNumber);
            if (rowsAffected == 0) 
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.Conflict);
            }
            return _context.SaveChangesAsync(token);
        }

        public Task SaleTicket(SaleTicket ticket, CancellationToken token)
        {
            _context.Database.ExecuteSqlRaw(BEGIN_TRAN_QUERY);
            int rowsAffected;
            int serial_number = 1;
            foreach (var segment in ticket.Routes)
            {
                var segmentDbModel = _mapper.Map<SegmentDbModel>(segment);
                rowsAffected = _context.Database.ExecuteSqlRaw(INSERT_INTO_SEGMENTS_QUERY, ticket.Passenger.TicketNumber, serial_number++, segmentDbModel.AirlineCode,
                    segmentDbModel.FlightNumber, segmentDbModel.DepartPlace, segmentDbModel.DepartDatetime, segmentDbModel.DepartTimeZone,
                    segmentDbModel.ArrivePlace, segmentDbModel.ArriveDatetime, segmentDbModel.ArriveTimeZone, segmentDbModel.PnrId);
                
                if (rowsAffected == 0)
                {
                    _context.Database.ExecuteSqlRaw(ROLLBACK_TRAN_QUERY);
                    throw new HttpResponseException(System.Net.HttpStatusCode.Conflict);
                }
            }
            _context.Database.ExecuteSqlRaw(COMMIT_TRAN_QUERY);
            return _context.SaveChangesAsync(token);
        }
    }
}
