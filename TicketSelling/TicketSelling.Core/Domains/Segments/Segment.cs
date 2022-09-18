namespace TicketSelling.Core.Domains.Segments
{
    public class Segment
    {
        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string DepartPlace { get; set; }
        public DateTime DepartDatetime { get; set; }
        public string ArrivePlace { get; set; }
        public DateTime ArriveDatetime { get; set; }
        public string PnrId { get; set; }

        public Segment(string airlineCode, int flightNumber, string departPlace,
            DateTime departDatetime, string arrivePlace, DateTime arriveDatetime, string pnrId)
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
