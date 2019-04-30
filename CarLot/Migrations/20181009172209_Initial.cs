using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarLot.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Engine = table.Column<double>(nullable: false),
                    Doors = table.Column<int>(nullable: false),
                    Fuel = table.Column<string>(nullable: true),
                    Gearbox = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car");
        }
    }
}
