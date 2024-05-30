using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETM.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedBaseEntityForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_CreatedBy",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1363), new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1363) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 18, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1365), new DateTime(2024, 4, 19, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1371) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1391), new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1391) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1393), new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn", "Email", "ImageUri", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "enosisbd@gmail.com", "/enosis.png", null, null, "Admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn", "Email", "ImageUri", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 1, new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1261), "sabbir@gmail.com", "/sabbir.png", 1, new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1262), "Sabbir" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "ImageUri", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { 3, 1, new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1267), "Shimanto@gmail.com", "/photo.png", 1, new DateTime(2024, 4, 17, 10, 54, 56, 264, DateTimeKind.Utc).AddTicks(1267), "Shimanto" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketId",
                table: "Comments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CreatedBy",
                table: "Comments",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tickets_TicketId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_CreatedBy",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Users");

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
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(967), new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(969), new DateTime(2024, 4, 3, 5, 9, 19, 463, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "ImageUri", "Name" },
                values: new object[] { "sabbir@gmail.com", "/sabbir.png", "Sabbir" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "ImageUri", "Name" },
                values: new object[] { "Shimanto@gmail.com", "/photo.png", "Shimanto" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tickets_TicketId",
                table: "Comments",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_CreatedBy",
                table: "Comments",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreatedBy",
                table: "Tickets",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
