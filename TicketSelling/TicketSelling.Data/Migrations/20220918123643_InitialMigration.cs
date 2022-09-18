using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSelling.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "segments",
                columns: table => new
                {
                    ticket_number = table.Column<long>(type: "bigint", nullable: false),
                    serial_number = table.Column<int>(type: "integer", nullable: false),
                    airline_code = table.Column<string>(type: "text", nullable: false),
                    flight_number = table.Column<int>(type: "integer", nullable: false),
                    depart_place = table.Column<string>(type: "text", nullable: false),
                    depart_datetime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DepartTimeZone = table.Column<int>(type: "integer", nullable: false),
                    arrive_place = table.Column<string>(type: "text", nullable: false),
                    arrive_datetime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ArriveTimeZone = table.Column<int>(type: "integer", nullable: false),
                    pnr_id = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_segment_id", x => new { x.ticket_number, x.serial_number });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "segments");
        }
    }
}
