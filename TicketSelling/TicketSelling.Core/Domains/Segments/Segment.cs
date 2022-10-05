namespace TicketSelling.Core.Domains.Segments
{
    public class Segment
    {
        public string AirlineCode { get; private set; }
        public int FlightNumber { get; private set; }
        public string DepartPlace { get; private set; }
        public DateTimeOffset DepartDatetime { get; private set; }
        public string ArrivePlace { get; private set; }
        public DateTimeOffset ArriveDatetime { get; private set; }
        public string PnrId { get; private set; }

        public Segment(string airlineCode, int flightNumber, string departPlace,
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
