namespace TicketSelling.Core.Domains.Segments
{
    public class Segment
    {
        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string DepartPlace { get; set; }
        public DateTimeOffset DepartDatetime { get; set; }
        public string ArrivePlace { get; set; }
        public DateTimeOffset ArriveDatetime { get; set; }
        public string PnrId { get; set; }

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
