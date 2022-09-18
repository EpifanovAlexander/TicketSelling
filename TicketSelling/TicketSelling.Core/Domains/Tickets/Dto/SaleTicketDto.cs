using System.Text.Json.Serialization;
using TicketSelling.Core.Domains.Passengers.Dto;
using TicketSelling.Core.Domains.Segments.Dto;

namespace TicketSelling.Core.Domains.Tickets.Dto
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
