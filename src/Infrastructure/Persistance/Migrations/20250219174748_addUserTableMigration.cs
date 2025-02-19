using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addUserTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Arls",
                keyColumn: "Id",
                keyValue: new Guid("547f51da-9545-4a7b-b8bd-0a73c8411e26"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 19, 12, 47, 48, 447, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Arls",
                keyColumn: "Id",
                keyValue: new Guid("f47a4416-8b3a-4e6c-80f4-785e7391b23f"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 19, 12, 47, 48, 447, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Epss",
                keyColumn: "Id",
                keyValue: new Guid("8e0c872e-f1f6-456a-8bcf-3a6b7a2a7c98"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 19, 12, 47, 48, 447, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Epss",
                keyColumn: "Id",
                keyValue: new Guid("c5a65b34-334f-4355-a8b7-0098d92c7f8e"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 19, 12, 47, 48, 447, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Pensions",
                keyColumn: "Id",
                keyValue: new Guid("880f4e17-7bd1-4b86-a51c-fd5b65b2c33d"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 19, 12, 47, 48, 447, DateTimeKind.Local).AddTicks(938));

            migrationBuilder.UpdateData(
                table: "Pensions",
                keyColumn: "Id",
                keyValue: new Guid("debead27-46a2-446f-8597-ab06b88695b1"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 19, 12, 47, 48, 447, DateTimeKind.Local).AddTicks(938));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Arls",
                keyColumn: "Id",
                keyValue: new Guid("547f51da-9545-4a7b-b8bd-0a73c8411e26"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Arls",
                keyColumn: "Id",
                keyValue: new Guid("f47a4416-8b3a-4e6c-80f4-785e7391b23f"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Epss",
                keyColumn: "Id",
                keyValue: new Guid("8e0c872e-f1f6-456a-8bcf-3a6b7a2a7c98"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Epss",
                keyColumn: "Id",
                keyValue: new Guid("c5a65b34-334f-4355-a8b7-0098d92c7f8e"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Pensions",
                keyColumn: "Id",
                keyValue: new Guid("880f4e17-7bd1-4b86-a51c-fd5b65b2c33d"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817));

            migrationBuilder.UpdateData(
                table: "Pensions",
                keyColumn: "Id",
                keyValue: new Guid("debead27-46a2-446f-8597-ab06b88695b1"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 18, 11, 46, 6, 343, DateTimeKind.Local).AddTicks(3817));
        }
    }
}
