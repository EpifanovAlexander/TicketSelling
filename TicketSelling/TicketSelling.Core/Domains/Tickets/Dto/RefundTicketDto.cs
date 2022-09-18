using System.Text.Json.Serialization;

namespace TicketSelling.Core.Domains.Tickets.Dto
{
    public class RefundTicketDto
    {
        [JsonPropertyName("operation_type")]
        public string OperationType { get; set; }

        [JsonPropertyName("operation_time")]
        public DateTimeOffset OperationTime { get; set; }

        [JsonPropertyName("operation_place")]
        public string OperationPlace { get; set; }

        [JsonPropertyName("ticket_number")]
        public string TicketNumber { get; set; }

        public RefundTicketDto(string operationType, DateTimeOffset operationTime, string operationPlace, string ticketNumber)
        {
            OperationType = operationType;
            OperationTime = operationTime;
            OperationPlace = operationPlace;
            TicketNumber = ticketNumber;
        }
    }
}
