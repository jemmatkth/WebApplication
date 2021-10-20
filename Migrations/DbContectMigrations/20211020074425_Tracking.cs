using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WebApplication.Migrations.DbContectMigrations
{
    public partial class Tracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Tracking",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                   Logged = table.Column<DateTime>(type: "datetime2", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Tracking", x => x.Id);
               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
