using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSelling.Core.Domains.Passengers.Dto;
using TicketSelling.Core.Domains.Segments.Dto;

namespace TicketSelling.Core.Domains.Tickets.Dto
{
    public class SaleTicketDto
    {
        [Required(ErrorMessage = "Тип операции должен быть определён")]
        [JsonPropertyName("operation_type")]
        public string OperationType { get; private set; }

        [JsonPropertyName("operation_time")]
        public DateTimeOffset OperationTime { get; private set; }

        [JsonPropertyName("operation_place")]
        public string OperationPlace { get; private set; }

        [Required(ErrorMessage = "У билета должен быть пассажир")]
        [JsonPropertyName("passenger")]
        public PassengerDto Passenger { get; private set; }

        [Required(ErrorMessage = "В билете должен быть хотя бы один сегмент маршрута")]
        [JsonPropertyName("routes")]
        public IEnumerable<SegmentDto> Routes { get; private set; }

        public SaleTicketDto(string operationType, DateTimeOffset operationTime, string operationPlace, 
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
