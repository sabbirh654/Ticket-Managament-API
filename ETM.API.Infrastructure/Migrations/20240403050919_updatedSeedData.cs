using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETM.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(934), new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(936) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 4, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(940), new DateTime(2024, 4, 5, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(947) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { 1, new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(967), 1, new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { 1, new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(969), 1, new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(969) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 3, 5, 0, 25, 30, DateTimeKind.Utc).AddTicks(4790), new DateTime(2024, 4, 3, 5, 0, 25, 30, DateTimeKind.Utc).AddTicks(4791) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 4, 5, 0, 25, 30, DateTimeKind.Utc).AddTicks(4796), new DateTime(2024, 4, 5, 5, 0, 25, 30, DateTimeKind.Utc).AddTicks(4803) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[] { 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null });
        }
    }
}
