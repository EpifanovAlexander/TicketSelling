using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TicketSelling.Core.Domains.Segments.Dto
{
    public class SegmentDto
    {
        [Required(ErrorMessage = "Поле \"airline_code\" было не определено")]
        [JsonPropertyName("airline_code")]
        public string AirlineCode { get; set; }

        [Required(ErrorMessage = "Поле \"flight_num\" было не определено")]
        [JsonPropertyName("flight_num")]
        public int FlightNumber { get; set; }

        [Required(ErrorMessage = "Поле \"depart_place\" было не определено")]
        [JsonPropertyName("depart_place")]
        public string DepartPlace { get; set; }

        [Required(ErrorMessage = "Поле \"depart_datetime\" было не определено")]
        [JsonPropertyName("depart_datetime")]
        public DateTimeOffset DepartDatetime { get; set; }

        [Required(ErrorMessage = "Поле \"arrive_place\" было не определено")]
        [JsonPropertyName("arrive_place")]
        public string ArrivePlace { get; set; }

        [Required(ErrorMessage = "Поле \"arrive_datetime\" было не определено")]
        [JsonPropertyName("arrive_datetime")]
        public DateTimeOffset ArriveDatetime { get; set; }

        [Required(ErrorMessage = "Поле \"pnr_id\" было не определено")]
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
