namespace TicketSelling.Core.Domains.Passengers
{
    public class Passenger
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public string DocumentType { get; private set; }
        public string DocumentNumber { get; private set; }
        public DateTime Birthdate { get; private set; }
        public char Gender { get; private set; }
        public string PassengerType { get; private set; }
        public string TicketNumber { get; private set; }
        public int TicketType { get; private set; }

        public Passenger(string name, string surname, string patronymic, string documentType, string documentNumber,
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
