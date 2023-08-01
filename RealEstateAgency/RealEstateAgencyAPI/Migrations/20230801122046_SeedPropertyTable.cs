using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealEstateAgencyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedPropertyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedDate", "Details", "ImageURL", "Name", "SquareMeters", "Type" },
                values: new object[,]
                {
                    { 1, "Stadiou Street 7", "Kavos", "Greece", new DateTime(2023, 8, 1, 14, 20, 45, 855, DateTimeKind.Local).AddTicks(1959), "50 meters from the beach", "https://i.pinimg.com/1200x/4d/37/32/4d37324143b5f5a0ecca431b66a60e12.jpg", "Beach House", 76.0, "House" },
                    { 2, "9th Avenue 143", "New York City", "United States of America", new DateTime(2023, 8, 1, 14, 20, 45, 855, DateTimeKind.Local).AddTicks(1986), "5th floor", "https://images1.apartments.com/i2/gV9g9N4i55VYrA8JKF-ECZVproGO3WaVB8FQpuKY7DQ/111/746-9th-ave-new-york-ny-primary-photo.jpg", "NYC Appartment", 83.0, "Appartment" },
                    { 3, "Partizanska 34", "Novi Sad", "Serbia", new DateTime(2023, 8, 1, 14, 20, 45, 855, DateTimeKind.Local).AddTicks(2003), "Suburbs of Novi Sad", "https://m3.spitogatos.gr/259892801_300x220.jpg?v=20130730", "Industrial warehouse", 3267.0, "Warehouse" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
