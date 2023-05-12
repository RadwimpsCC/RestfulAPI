using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeXiecheng.API.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "Id", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Features", "Fees", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("00755299-a37f-4e8e-ad19-8ee5051fc9a4"), new DateTime(2023, 5, 10, 8, 21, 16, 164, DateTimeKind.Utc).AddTicks(5137), null, "1", null, null, null, null, 0m, "Test", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "Id",
                keyValue: new Guid("00755299-a37f-4e8e-ad19-8ee5051fc9a4"));
        }
    }
}
