using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KidsBooks.Migrations
{
    public partial class initialisecategoriestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date_Added",
                value: new DateTime(2020, 11, 18, 22, 37, 44, 96, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date_Added",
                value: new DateTime(2020, 11, 18, 22, 37, 44, 109, DateTimeKind.Local).AddTicks(5074));

            migrationBuilder.Sql(@"Insert into Categories(Name) Values('Classic')");
            migrationBuilder.Sql(@"Insert into Categories(Name) values('Adventure')");
            migrationBuilder.Sql(@"Insert into Categories(Name) values('Comedy')");
            migrationBuilder.Sql(@"Insert into Categories(Name) Values('Fantacy')");
            migrationBuilder.Sql(@"Insert into Categories(Name) values('Romance')");
            migrationBuilder.Sql(@"Insert into Categories(Name) values('Horror')");
            migrationBuilder.Sql(@"Insert into Categories(Name) Values('Thriller')");
            migrationBuilder.Sql(@"Insert into Categories(Name) values('Contemporary')");
            migrationBuilder.Sql(@"Insert into Categories(Name) values('None')");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date_Added",
                value: new DateTime(2020, 11, 18, 22, 12, 51, 501, DateTimeKind.Local).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date_Added",
                value: new DateTime(2020, 11, 18, 22, 12, 51, 515, DateTimeKind.Local).AddTicks(6797));
        }
    }
}
