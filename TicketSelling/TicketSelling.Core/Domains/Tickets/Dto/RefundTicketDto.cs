using System.Text.Json.Serialization;

namespace TicketSelling.Core.Domains.Tickets.Dto
{
    public class RefundTicketDto
    {
        [JsonPropertyName("operation_type")]
        public string OperationType { get; set; }

        [JsonPropertyName("operation_time")]
        public DateTime OperationTime { get; set; }

        [JsonPropertyName("operation_place")]
        public string OperationPlace { get; set; }

        [JsonPropertyName("ticket_number")]
        public long TicketNumber { get; set; }

        public RefundTicketDto(string operationType, DateTime operationTime, string operationPlace, long ticketNumber)
        {
            OperationType = operationType;
            OperationTime = operationTime;
            OperationPlace = operationPlace;
            TicketNumber = ticketNumber;
        }
    }
}
