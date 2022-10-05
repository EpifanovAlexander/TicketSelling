using TicketSelling.Core.Domains.Passengers;
using TicketSelling.Core.Domains.Segments;

namespace TicketSelling.Core.Domains.Tickets
{
    public class SaleTicket
    {
        public string OperationType { get; private set; }
        public DateTimeOffset OperationTime { get; private set; }
        public string OperationPlace { get; private set; }
        public Passenger Passenger { get; private set; }
        public IEnumerable<Segment> Routes { get; private set; }

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
