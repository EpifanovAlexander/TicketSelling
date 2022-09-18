using System.Text.Json.Serialization;

namespace TicketSelling.Core.Domains.Segments.Dto
{
    public class SegmentDto
    {
        [JsonPropertyName("airline_code")]
        public string AirlineCode { get; set; }

        [JsonPropertyName("flight_num")]
        public int FlightNumber { get; set; }

        [JsonPropertyName("depart_place")]
        public string DepartPlace { get; set; }

        [JsonPropertyName("depart_datetime")]
        public DateTimeOffset DepartDatetime { get; set; }

        [JsonPropertyName("arrive_place")]
        public string ArrivePlace { get; set; }

        [JsonPropertyName("arrive_datetime")]
        public DateTimeOffset ArriveDatetime { get; set; }

        [JsonPropertyName("pnr_id")]
        public string PnrId { get; set; }

        public SegmentDto(string airlineCode, int flightNumber, string departPlace,
            DateTimeOffset departDatetime, string arrivePlace, DateTimeOffset arriveDatetime, string pnrId)
        {
            AirlineCode = airlineCode;
            FlightNumber = flightNumber;
            DepartPlace = departPlace;
            DepartDatetime = departDatetime;
            ArrivePlace = arrivePlace;
            ArriveDatetime = arriveDatetime;
            PnrId = pnrId;
        }
    }
}
