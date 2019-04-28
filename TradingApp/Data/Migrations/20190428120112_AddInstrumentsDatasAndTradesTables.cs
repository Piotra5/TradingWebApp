using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradingApp.Data.Migrations
{
    public partial class AddInstrumentsDatasAndTradesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: false),
                    AvailableFrom = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentsMarketDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InstrumentId = table.Column<string>(nullable: true),
                    ExpirationTime = table.Column<DateTimeOffset>(nullable: true),
                    CreationTime = table.Column<DateTimeOffset>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InstrumenId = table.Column<string>(nullable: true),
                    InstrumentMarketDataId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    OpeningPrice = table.Column<float>(nullable: false),
                    Size = table.Column<float>(nullable: false),
                    InstrumentId = table.Column<Guid>(nullable: true),
                    InstrumentMarketDataId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trades_InstrumentsMarketDatas_InstrumentMarketDataId1",
                        column: x => x.InstrumentMarketDataId1,
                        principalTable: "InstrumentsMarketDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trades_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentsMarketDatas_InstrumentId1",
                table: "InstrumentsMarketDatas",
                column: "InstrumentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_InstrumentId",
                table: "Trades",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_InstrumentMarketDataId1",
                table: "Trades",
                column: "InstrumentMarketDataId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserId",
                table: "Trades",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "InstrumentsMarketDatas");

            migrationBuilder.DropTable(
                name: "Instruments");
        }
    }
}
