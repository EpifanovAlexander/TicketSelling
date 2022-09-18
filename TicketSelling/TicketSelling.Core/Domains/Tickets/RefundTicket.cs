namespace TicketSelling.Core.Domains.Tickets
{
    public class RefundTicket
    {
        public string OperationType { get; set; }
        public DateTime OperationTime { get; set; }
        public string OperationPlace { get; set; }
        public long TicketNumber { get; set; }

        public RefundTicket(string operationType, DateTime operationTime, string operationPlace, long ticketNumber)
        {
            OperationType = operationType;
            OperationTime = operationTime;
            OperationPlace = operationPlace;
            TicketNumber = ticketNumber;
        }
    }
}
