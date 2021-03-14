using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Expence",
                columns: table => new
                {
                    ExpenceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenceCode = table.Column<string>(nullable: false),
                    ExpenceName = table.Column<string>(nullable: false),
                    ExpenceStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Expence", x => x.ExpenceId);
                });

            migrationBuilder.CreateTable(
                name: "T_Firm",
                columns: table => new
                {
                    FirmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmType = table.Column<short>(nullable: false),
                    FirmCode = table.Column<string>(nullable: false),
                    FirmName = table.Column<string>(nullable: false),
                    FirmStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Firm", x => x.FirmId);
                });

            migrationBuilder.CreateTable(
                name: "T_InvoiceIn",
                columns: table => new
                {
                    InvoiceInId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceInNo = table.Column<string>(nullable: true),
                    InvoiceInDate = table.Column<DateTime>(nullable: false),
                    Firm_Id = table.Column<int>(nullable: false),
                    FirmId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    InvoiceInStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_InvoiceIn", x => x.InvoiceInId);
                    table.ForeignKey(
                        name: "FK_T_InvoiceIn_T_Firm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "T_Firm",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_InvoiceOut",
                columns: table => new
                {
                    InvoiceOutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceOutNo = table.Column<string>(nullable: true),
                    InvoiceOutDate = table.Column<DateTime>(nullable: false),
                    FirmId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    InvoiceOutStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_InvoiceOut", x => x.InvoiceOutId);
                    table.ForeignKey(
                        name: "FK_T_InvoiceOut_T_Firm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "T_Firm",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_CashOut",
                columns: table => new
                {
                    CashOutId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashOutNo = table.Column<string>(nullable: false),
                    CashOutDate = table.Column<DateTime>(nullable: false),
                    Firm_Id = table.Column<int>(nullable: false),
                    FirmId = table.Column<int>(nullable: true),
                    InvoiceInId = table.Column<int>(nullable: false),
                    CashOutTotal = table.Column<decimal>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CashOutStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CashOut", x => x.CashOutId);
                    table.ForeignKey(
                        name: "FK_T_CashOut_T_Firm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "T_Firm",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_CashOut_T_InvoiceIn_InvoiceInId",
                        column: x => x.InvoiceInId,
                        principalTable: "T_InvoiceIn",
                        principalColumn: "InvoiceInId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_InvoiceInLine",
                columns: table => new
                {
                    InvoiceInLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceInId = table.Column<int>(nullable: false),
                    ExpenceId = table.Column<int>(nullable: false),
                    InvoiceInLineQuantity = table.Column<int>(nullable: false),
                    InvoiceInLinePrice = table.Column<decimal>(nullable: false),
                    InvoiceInLineTotal = table.Column<decimal>(nullable: false),
                    InvoiceInLineStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_InvoiceInLine", x => x.InvoiceInLineId);
                    table.ForeignKey(
                        name: "FK_T_InvoiceInLine_T_Expence_ExpenceId",
                        column: x => x.ExpenceId,
                        principalTable: "T_Expence",
                        principalColumn: "ExpenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_InvoiceInLine_T_InvoiceIn_InvoiceInId",
                        column: x => x.InvoiceInId,
                        principalTable: "T_InvoiceIn",
                        principalColumn: "InvoiceInId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_CashIn",
                columns: table => new
                {
                    CashInId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashInNo = table.Column<string>(nullable: false),
                    CashInDate = table.Column<DateTime>(nullable: false),
                    Firm_Id = table.Column<int>(nullable: false),
                    FirmId = table.Column<int>(nullable: true),
                    InvoiceOutId = table.Column<int>(nullable: false),
                    CshInTotal = table.Column<decimal>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CashInStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_CashIn", x => x.CashInId);
                    table.ForeignKey(
                        name: "FK_T_CashIn_T_Firm_FirmId",
                        column: x => x.FirmId,
                        principalTable: "T_Firm",
                        principalColumn: "FirmId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_T_CashIn_T_InvoiceOut_InvoiceOutId",
                        column: x => x.InvoiceOutId,
                        principalTable: "T_InvoiceOut",
                        principalColumn: "InvoiceOutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_InvoiceOutLine",
                columns: table => new
                {
                    InvoiceOutLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceOutId = table.Column<int>(nullable: false),
                    ExpenceId = table.Column<int>(nullable: false),
                    InvoiceOutLineQuantity = table.Column<int>(nullable: false),
                    InvoiceOutLinePrice = table.Column<decimal>(nullable: false),
                    InvoiceOutLineTotal = table.Column<decimal>(nullable: false),
                    InvoiceOutLineStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_InvoiceOutLine", x => x.InvoiceOutLineId);
                    table.ForeignKey(
                        name: "FK_T_InvoiceOutLine_T_Expence_ExpenceId",
                        column: x => x.ExpenceId,
                        principalTable: "T_Expence",
                        principalColumn: "ExpenceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_InvoiceOutLine_T_InvoiceOut_InvoiceOutId",
                        column: x => x.InvoiceOutId,
                        principalTable: "T_InvoiceOut",
                        principalColumn: "InvoiceOutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_CashIn_FirmId",
                table: "T_CashIn",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CashIn_InvoiceOutId",
                table: "T_CashIn",
                column: "InvoiceOutId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CashOut_FirmId",
                table: "T_CashOut",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_T_CashOut_InvoiceInId",
                table: "T_CashOut",
                column: "InvoiceInId");

            migrationBuilder.CreateIndex(
                name: "IX_T_InvoiceIn_FirmId",
                table: "T_InvoiceIn",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_T_InvoiceInLine_ExpenceId",
                table: "T_InvoiceInLine",
                column: "ExpenceId");

            migrationBuilder.CreateIndex(
                name: "IX_T_InvoiceInLine_InvoiceInId",
                table: "T_InvoiceInLine",
                column: "InvoiceInId");

            migrationBuilder.CreateIndex(
                name: "IX_T_InvoiceOut_FirmId",
                table: "T_InvoiceOut",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_T_InvoiceOutLine_ExpenceId",
                table: "T_InvoiceOutLine",
                column: "ExpenceId");

            migrationBuilder.CreateIndex(
                name: "IX_T_InvoiceOutLine_InvoiceOutId",
                table: "T_InvoiceOutLine",
                column: "InvoiceOutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_CashIn");

            migrationBuilder.DropTable(
                name: "T_CashOut");

            migrationBuilder.DropTable(
                name: "T_InvoiceInLine");

            migrationBuilder.DropTable(
                name: "T_InvoiceOutLine");

            migrationBuilder.DropTable(
                name: "T_InvoiceIn");

            migrationBuilder.DropTable(
                name: "T_Expence");

            migrationBuilder.DropTable(
                name: "T_InvoiceOut");

            migrationBuilder.DropTable(
                name: "T_Firm");
        }
    }
}
