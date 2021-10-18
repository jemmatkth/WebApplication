using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations.DbContectMigrations
{
    public partial class Username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUsername",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SentToUsername",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUsername",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SentToUsername",
                table: "Message");
        }
    }
}
