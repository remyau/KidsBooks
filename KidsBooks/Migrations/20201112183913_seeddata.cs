using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidsBooks.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Date_Added", "Date_Published", "Name", "Publisher" },
                values: new object[] { 1, "Author Name", new DateTime(2020, 11, 12, 13, 39, 11, 849, DateTimeKind.Local).AddTicks(9931), new DateTime(1889, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book Name", "Publisher" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Date_Added", "Date_Published", "Name", "Publisher" },
                values: new object[] { 2, "Author Name Other", new DateTime(2020, 11, 12, 13, 39, 11, 858, DateTimeKind.Local).AddTicks(3526), new DateTime(1889, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book Name other", "Publisher Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
