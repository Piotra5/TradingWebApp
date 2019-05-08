using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingApp.Data.Migrations
{
    public partial class updatedinstrument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "InstrumentsMarketData",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Instruments",
                newName: "ToName");

            migrationBuilder.AddColumn<float>(
                name: "ExchangeRate",
                table: "InstrumentsMarketData",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "FromCode",
                table: "Instruments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromName",
                table: "Instruments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToCode",
                table: "Instruments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "InstrumentsMarketData");

            migrationBuilder.DropColumn(
                name: "FromCode",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "FromName",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "ToCode",
                table: "Instruments");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "InstrumentsMarketData",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ToName",
                table: "Instruments",
                newName: "Name");
        }
    }
}
