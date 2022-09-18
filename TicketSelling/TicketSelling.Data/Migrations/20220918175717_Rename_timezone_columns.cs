using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSelling.Data.Migrations
{
    public partial class Rename_timezone_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartTimeZone",
                table: "segments",
                newName: "depart_datetime_timezone");

            migrationBuilder.RenameColumn(
                name: "ArriveTimeZone",
                table: "segments",
                newName: "arrive_datetime_timezone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "depart_datetime_timezone",
                table: "segments",
                newName: "DepartTimeZone");

            migrationBuilder.RenameColumn(
                name: "arrive_datetime_timezone",
                table: "segments",
                newName: "ArriveTimeZone");
        }
    }
}
