using Microsoft.EntityFrameworkCore.Migrations;

namespace KidsBooks.Migrations
{
    public partial class updatebookcategorytonone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Update Books set CategoryId=9");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
