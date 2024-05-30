using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETM.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 1, 4, 17, 31, 148, DateTimeKind.Utc).AddTicks(2063), new DateTime(2024, 4, 1, 4, 17, 31, 148, DateTimeKind.Utc).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 2, 4, 17, 31, 148, DateTimeKind.Utc).AddTicks(2067), new DateTime(2024, 4, 3, 4, 17, 31, 148, DateTimeKind.Utc).AddTicks(2073) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 29, 12, 16, 22, 883, DateTimeKind.Utc).AddTicks(4974), new DateTime(2024, 3, 29, 12, 16, 22, 883, DateTimeKind.Utc).AddTicks(4976) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 30, 12, 16, 22, 883, DateTimeKind.Utc).AddTicks(4979), new DateTime(2024, 3, 31, 12, 16, 22, 883, DateTimeKind.Utc).AddTicks(4989) });
        }
    }
}
