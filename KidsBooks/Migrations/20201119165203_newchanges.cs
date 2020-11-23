using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidsBooks.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Date_Added", "Name", "Publisher" },
                values: new object[] { "None", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "None", "None" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Author", "Date_Added", "Name", "Publisher" },
                values: new object[] { "Author Name", new DateTime(2020, 11, 18, 22, 37, 44, 96, DateTimeKind.Local).AddTicks(1147), "Book Name", "Publisher" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Date_Added", "Date_Published", "Description", "Name", "Publisher" },
                values: new object[] { 2, "Author Name Other", 0, new DateTime(2020, 11, 18, 22, 37, 44, 109, DateTimeKind.Local).AddTicks(5074), new DateTime(1889, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Book Name other", "Publisher Other" });
        }
    }
}
