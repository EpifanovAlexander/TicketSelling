namespace TicketSelling.Core.Domains.Tickets
{
    public class RefundTicket
    {
        public string OperationType { get; private set; }
        public DateTimeOffset OperationTime { get; private set; }
        public string OperationPlace { get; private set; }
        public string TicketNumber { get; private set; }

        public RefundTicket(string operationType, DateTimeOffset operationTime, string operationPlace, string ticketNumber)
        {
            OperationType = operationType;
            OperationTime = operationTime;
            OperationPlace = operationPlace;
            TicketNumber = ticketNumber;
        }
    }
}
