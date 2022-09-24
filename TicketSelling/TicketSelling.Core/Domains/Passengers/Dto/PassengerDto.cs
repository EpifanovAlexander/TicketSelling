using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TicketSelling.Core.ValidationAttributes;

namespace TicketSelling.Core.Domains.Passengers.Dto
{
    [PassengerValidation]
    public class PassengerDto
    {
        [Required(ErrorMessage = "Имя пассажира не может быть пустым")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия пассажира не может быть пустой")]
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Тип документа должен быть определён")]
        [JsonPropertyName("doc_type")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Номер документа должен быть определён")]
        [JsonPropertyName("doc_number")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "Дата рождения пассажира не может быть пустой")]
        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonPropertyName("gender")]
        public char Gender { get; set; }

        [JsonPropertyName("passenger_type")]
        public string PassengerType { get; set; }

        [Required(ErrorMessage = "Номер билета должен быть определён")]
        [RegularExpression(@"^(\d{13})$", ErrorMessage = "Невалидный номер билета")]
        [JsonPropertyName("ticket_number")]
        public string TicketNumber { get; set; }

        [Required(ErrorMessage = "Тип билета должен быть определён")]
        [JsonPropertyName("ticket_type")]
        public int TicketType { get; set; }

        public PassengerDto(string name, string surname, string patronymic, string documentType, string documentNumber, 
            DateTime birthdate, char gender, string passengerType, string ticketNumber, int ticketType)
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
