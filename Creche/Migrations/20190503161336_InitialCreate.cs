using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Creche.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pps = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Dob = table.Column<DateTime>(nullable: false),
                    ParentFirstName = table.Column<string>(nullable: false),
                    ParentLastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: false),
                    SecondNumber = table.Column<string>(nullable: true),
                    OtherNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    SecondEmail = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Relationship = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Hours = table.Column<string>(nullable: false),
                    Days = table.Column<string>(nullable: true),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
