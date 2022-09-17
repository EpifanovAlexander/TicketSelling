using System.Text.Json.Serialization;

namespace TicketSelling.Controllers.Tickets.Dto
{
    public class SaleTicketDto
    {
        [JsonPropertyName("operation_type")]
        public string OperationType { get; set; }

        [JsonPropertyName("operation_time")]
        public DateTime OperationTime { get; set; }

        [JsonPropertyName("operation_place")]
        public string OperationPlace { get; set; }

        [JsonPropertyName("passenger")]
        public PassengerDto Passenger { get; set; }

        [JsonPropertyName("routes")]
        public IEnumerable<SegmentDto> Routes { get; set; }

        public SaleTicketDto(string operationType, DateTime operationTime, string operationPlace, 
            PassengerDto passenger, IEnumerable<SegmentDto> routes)
        {
            OperationType = operationType;
            OperationTime = operationTime;
            OperationPlace = operationPlace;
            Passenger = passenger;
            Routes = routes;
        }
    }
}
