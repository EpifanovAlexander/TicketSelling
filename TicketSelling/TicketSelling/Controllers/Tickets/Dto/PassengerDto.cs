using System.Text.Json.Serialization;

namespace TicketSelling.Controllers.Tickets.Dto
{
    public class PassengerDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [JsonPropertyName("doc_type")]
        public string DocumentType { get; set; }

        [JsonPropertyName("doc_number")]
        public long DocumentNumber { get; set; }

        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("gender")]
        public char Gender { get; set; }

        [JsonPropertyName("passenger_type")]
        public string PassengerType { get; set; }

        [JsonPropertyName("ticket_number")]
        public long TicketNumber { get; set; }

        [JsonPropertyName("ticket_type")]
        public int TicketType { get; set; }

        public PassengerDto(string name, string surname, string patronymic, string documentType, long documentNumber, 
            DateTime birthdate, char gender, string passengerType, long ticketNumber, int ticketType)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DocumentType = documentType;
            DocumentNumber = documentNumber;
            Birthdate = birthdate;
            Gender = gender;
            PassengerType = passengerType;
            TicketNumber = ticketNumber;
            TicketType = ticketType;
        }
    }
}
