using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "IC", new DateOnly(1928, 7, 18), "Intel Corporation" },
                    { 2, "AMD", new DateOnly(1969, 5, 1), "Advanced Micro Devices" },
                    { 3, "NC", new DateOnly(1993, 4, 5), "Nvidia Corporation" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "CPU", "Processor" },
                    { 2, "GPU", "Graphics Card" },
                    { 3, "RAM", "Memory" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Beast X", 5, 36, 12.5f },
                    { 2, new DateTime(2026, 4, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), "Office Mini Pro", 12, 24, 4.2f },
                    { 3, new DateTime(2026, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Workstation Ultra", 3, 48, 18f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturersId", "ComponentTypesId", "Description", "Name" },
                values: new object[,]
                {
                    { "CPU001   ", 1, 1, "High-end desktop CPU", "Intel Core i9-14900K" },
                    { "GPU001   ", 3, 3, "Flagship gaming GPU", "RTX 4090" },
                    { "RAM001   ", 2, 2, "DDR5 5600MHz RAM", "Kingston 32GB DDR5" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PCId", "Amount" },
                values: new object[,]
                {
                    { "CPU001   ", 1, 1 },
                    { "GPU001   ", 1, 1 },
                    { "RAM001   ", 2, 2 },
                    { "CPU001   ", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "CPU001   ", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "GPU001   ", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "RAM001   ", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "CPU001   ", 3 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "CPU001   ");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "GPU001   ");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "RAM001   ");

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
