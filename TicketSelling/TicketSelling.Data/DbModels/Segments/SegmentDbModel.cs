using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TicketSelling.Data.DbModels.Segments
{
    public class SegmentDbModel
    {
        public string TicketNumber { get; set; }
        public int SerialNumber { get; set; }
        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string DepartPlace { get; set; }
        public DateTimeOffset DepartDatetime { get; set; }
        public int DepartTimeZone { get; private set; }
        public string ArrivePlace { get; set; }
        public DateTimeOffset ArriveDatetime { get; set; }
        public int ArriveTimeZone { get; private set; }
        public string PnrId { get; set; }
        public string State { get; set; }

        public SegmentDbModel(string airlineCode, int flightNumber, string departPlace,
            DateTimeOffset departDatetime, string arrivePlace, DateTimeOffset arriveDatetime, string pnrId)
        {
            AirlineCode = airlineCode;
            FlightNumber = flightNumber;
            DepartPlace = departPlace;
            DepartDatetime = departDatetime;
            DepartTimeZone = departDatetime.Offset.Hours;
            ArrivePlace = arrivePlace;
            ArriveDatetime = arriveDatetime;
            ArriveTimeZone = arriveDatetime.Offset.Hours;
            PnrId = pnrId;
        }

        internal class Map : IEntityTypeConfiguration<SegmentDbModel>
        {
            public void Configure(EntityTypeBuilder<SegmentDbModel> builder)
            {
                builder.ToTable("segments");

                builder.Property(it => it.TicketNumber)
                    .HasColumnName("ticket_number")
                    .IsRequired();

                builder.Property(it => it.SerialNumber)
                    .HasColumnName("serial_number")
                    .IsRequired();

                builder.Property(it => it.AirlineCode)
                    .HasColumnName("airline_code")
                    .IsRequired();

                builder.Property(it => it.FlightNumber)
                    .HasColumnName("flight_number")
                    .IsRequired();

                builder.Property(it => it.DepartPlace)
                    .HasColumnName("depart_place")
                    .IsRequired();

                builder.Property(it => it.DepartDatetime)
                    .HasColumnName("depart_datetime")
                    .IsRequired();

                builder.Property(it => it.DepartTimeZone)
                    .HasColumnName("depart_datetime_timezone");

                builder.Property(it => it.ArrivePlace)
                    .HasColumnName("arrive_place")
                    .IsRequired();

                builder.Property(it => it.ArriveDatetime)
                    .HasColumnName("arrive_datetime")
                    .IsRequired();

                builder.Property(it => it.ArriveTimeZone)
                    .HasColumnName("arrive_datetime_timezone");

                builder.Property(it => it.PnrId)
                    .HasColumnName("pnr_id")
                    .IsRequired();

                builder.Property(it => it.State)
                    .HasColumnName("state")
                    .IsRequired();

                builder.HasKey(segment => new { segment.TicketNumber, segment.SerialNumber })
                    .HasName("pk_segment_id");
            }
        }
    }
}
