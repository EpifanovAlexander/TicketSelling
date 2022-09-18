namespace TicketSelling.Core.Domains.Passengers
{
    public class Passenger
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string DocumentType { get; set; }
        public long DocumentNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }
        public string PassengerType { get; set; }
        public long TicketNumber { get; set; }
        public int TicketType { get; set; }

        public Passenger(string name, string surname, string patronymic, string documentType, long documentNumber,
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
