using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Epss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Epss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    ArlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EpsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PensionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Arls_ArlId",
                        column: x => x.ArlId,
                        principalTable: "Arls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Epss_EpsId",
                        column: x => x.EpsId,
                        principalTable: "Epss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Pensions_PensionId",
                        column: x => x.PensionId,
                        principalTable: "Pensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Arls",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("547f51da-9545-4a7b-b8bd-0a73c8411e26"), new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817), "Colpatria" },
                    { new Guid("f47a4416-8b3a-4e6c-80f4-785e7391b23f"), new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817), "Sura" }
                });

            migrationBuilder.InsertData(
                table: "Epss",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("8e0c872e-f1f6-456a-8bcf-3a6b7a2a7c98"), new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817), "Nueva EPS" },
                    { new Guid("c5a65b34-334f-4355-a8b7-0098d92c7f8e"), new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817), "Sanitas" }
                });

            migrationBuilder.InsertData(
                table: "Pensions",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("880f4e17-7bd1-4b86-a51c-fd5b65b2c33d"), new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817), "Protección" },
                    { new Guid("debead27-46a2-446f-8597-ab06b88695b1"), new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817), "Porvenir" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ArlId",
                table: "Employees",
                column: "ArlId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EpsId",
                table: "Employees",
                column: "EpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PensionId",
                table: "Employees",
                column: "PensionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Arls");

            migrationBuilder.DropTable(
                name: "Epss");

            migrationBuilder.DropTable(
                name: "Pensions");
        }
    }
}
