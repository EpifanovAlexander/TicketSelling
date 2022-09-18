using TicketSelling.Core.Domains.Passengers;
using TicketSelling.Core.Domains.Segments;

namespace TicketSelling.Core.Domains.Tickets
{
    public class SaleTicket
    {
        public string OperationType { get; set; }
        public DateTimeOffset OperationTime { get; set; }
        public string OperationPlace { get; set; }
        public Passenger Passenger { get; set; }
        public IEnumerable<Segment> Routes { get; set; }

        public SaleTicket(string operationType, DateTimeOffset operationTime, string operationPlace,
            Passenger passenger, IEnumerable<Segment> routes)
        {
            OperationType = operationType;
            OperationTime = operationTime;
            OperationPlace = operationPlace;
            Passenger = passenger;
            Routes = routes;
        }
    }
}
