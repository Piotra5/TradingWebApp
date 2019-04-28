using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingApp.Data.Migrations
{
    public partial class updateTradesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Instruments_InstrumentId",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_InstrumentsMarketDatas_InstrumentMarketDataId1",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_UserId",
                table: "Trades");

            migrationBuilder.DropTable(
                name: "InstrumentsMarketDatas");

            migrationBuilder.DropIndex(
                name: "IX_Trades_InstrumentId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "InstrumenId",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "InstrumentMarketDataId",
                table: "Trades");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Trades",
                newName: "IdentityUserId");

            migrationBuilder.RenameColumn(
                name: "InstrumentMarketDataId1",
                table: "Trades",
                newName: "InstrumentMId");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_UserId",
                table: "Trades",
                newName: "IX_Trades_IdentityUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_InstrumentMarketDataId1",
                table: "Trades",
                newName: "IX_Trades_InstrumentMId");

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentId",
                table: "Trades",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ClosingPrice",
                table: "Trades",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Trades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Laverage",
                table: "Trades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Long",
                table: "Trades",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "StopLoss",
                table: "Trades",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TargetPrice",
                table: "Trades",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstrumentsMarketData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InstrumentId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    AskPrice = table.Column<float>(nullable: false),
                    BidPrice = table.Column<float>(nullable: false),
                    InstrumentId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentsMarketData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentsMarketData_Instruments_InstrumentId1",
                        column: x => x.InstrumentId1,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentsMarketData_InstrumentId1",
                table: "InstrumentsMarketData",
                column: "InstrumentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_IdentityUserId",
                table: "Trades",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Instruments_InstrumentMId",
                table: "Trades",
                column: "InstrumentMId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trades_AspNetUsers_IdentityUserId",
                table: "Trades");

            migrationBuilder.DropForeignKey(
                name: "FK_Trades_Instruments_InstrumentMId",
                table: "Trades");

            migrationBuilder.DropTable(
                name: "InstrumentsMarketData");

            migrationBuilder.DropColumn(
                name: "ClosingPrice",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "Laverage",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "StopLoss",
                table: "Trades");

            migrationBuilder.DropColumn(
                name: "TargetPrice",
                table: "Trades");

            migrationBuilder.RenameColumn(
                name: "InstrumentMId",
                table: "Trades",
                newName: "InstrumentMarketDataId1");

            migrationBuilder.RenameColumn(
                name: "IdentityUserId",
                table: "Trades",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_InstrumentMId",
                table: "Trades",
                newName: "IX_Trades_InstrumentMarketDataId1");

            migrationBuilder.RenameIndex(
                name: "IX_Trades_IdentityUserId",
                table: "Trades",
                newName: "IX_Trades_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstrumentId",
                table: "Trades",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumenId",
                table: "Trades",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstrumentMarketDataId",
                table: "Trades",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstrumentsMarketDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
                    ExpirationTime = table.Column<DateTimeOffset>(nullable: true),
                    InstrumentId = table.Column<string>(nullable: true),
                    InstrumentId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentsMarketDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentsMarketDatas_Instruments_InstrumentId1",
                        column: x => x.InstrumentId1,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trades_InstrumentId",
                table: "Trades",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentsMarketDatas_InstrumentId1",
                table: "InstrumentsMarketDatas",
                column: "InstrumentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_Instruments_InstrumentId",
                table: "Trades",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_InstrumentsMarketDatas_InstrumentMarketDataId1",
                table: "Trades",
                column: "InstrumentMarketDataId1",
                principalTable: "InstrumentsMarketDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trades_AspNetUsers_UserId",
                table: "Trades",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
