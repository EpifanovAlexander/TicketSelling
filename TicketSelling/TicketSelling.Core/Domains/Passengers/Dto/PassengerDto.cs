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
        public string Name { get; private set; }

        [Required(ErrorMessage = "Фамилия пассажира не может быть пустой")]
        [JsonPropertyName("surname")]
        public string Surname { get; private set; }

        [JsonPropertyName("patronymic")]
        public string Patronymic { get; private set; }

        [Required(ErrorMessage = "Тип документа должен быть определён")]
        [JsonPropertyName("doc_type")]
        public string DocumentType { get; private set; }

        [Required(ErrorMessage = "Номер документа должен быть определён")]
        [JsonPropertyName("doc_number")]
        public string DocumentNumber { get; private set; }

        [Required(ErrorMessage = "Дата рождения пассажира не может быть пустой")]
        [JsonPropertyName("birthdate")]
        public DateTime Birthdate { get; private set; }

        [JsonPropertyName("gender")]
        public char Gender { get; private set; }

        [JsonPropertyName("passenger_type")]
        public string PassengerType { get; private set; }

        [Required(ErrorMessage = "Номер билета должен быть определён")]
        [RegularExpression(@"^(\d{13})$", ErrorMessage = "Невалидный номер билета")]
        [JsonPropertyName("ticket_number")]
        public string TicketNumber { get; private set; }

        [Required(ErrorMessage = "Тип билета должен быть определён")]
        [JsonPropertyName("ticket_type")]
        public int TicketType { get; private set; }

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
