using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Core;
using TicketSelling.Core.Domains.Segments.Repositories;
using TicketSelling.Core.Domains.Tickets;

namespace TicketSelling.Data.DbModels.Segments.Repositories
{
    public class SegmentRepository : ISegmentRepository
    {
        private const string SET_REFUND_STATE_QUERY = "UPDATE segments SET state = 'refund' WHERE ticket_number = {0} AND state <> 'refund';";
        private const string SET_LOCK_TIMEOUT_QUERY = "SET LOCAL lock_timeout = '120s';";
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

        public async Task RefundSegmentsByTicketNumberAsync(string ticketNumber, CancellationToken token)
        {
            using var dbContextTransaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, token);
            int rowsAffected = await _context.Database.ExecuteSqlRawAsync(SET_REFUND_STATE_QUERY, ticketNumber);
            if (rowsAffected == 0)
            {
                await _context.Database.RollbackTransactionAsync(token);
                await Task.FromException(new EntityException("Произошёл конфликт при обновлении данных"));
                return;
            }
            await _context.SaveChangesAsync(token);
            await dbContextTransaction.CommitAsync(token);
        }

        public async Task SaleTicketAsync(SaleTicket ticket, CancellationToken token)
        {
            using var dbContextTransaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable, token);
            await _context.Database.ExecuteSqlRawAsync(SET_LOCK_TIMEOUT_QUERY, token);

            int rowsAffected;
            int serial_number = 1;

            foreach (var segment in ticket.Routes)
            {
                var segmentDbModel = _mapper.Map<SegmentDbModel>(segment);
                rowsAffected = await _context.Database.ExecuteSqlRawAsync(INSERT_INTO_SEGMENTS_QUERY, ticket.Passenger.TicketNumber, serial_number++, segmentDbModel.AirlineCode,
                    segmentDbModel.FlightNumber, segmentDbModel.DepartPlace, segmentDbModel.DepartDatetime, segmentDbModel.DepartTimeZone,
                    segmentDbModel.ArrivePlace, segmentDbModel.ArriveDatetime, segmentDbModel.ArriveTimeZone, segmentDbModel.PnrId);

                if (rowsAffected == 0)
                {
                    await _context.Database.RollbackTransactionAsync(token);
                    await Task.FromException(new EntityException("Произошёл конфликт при обновлении данных"));
                    return;
                }
            }

            await _context.SaveChangesAsync(token);
            await dbContextTransaction.CommitAsync(token);
        }
    }
}
