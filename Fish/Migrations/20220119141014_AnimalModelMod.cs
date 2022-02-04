using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fish.Migrations
{
    public partial class AnimalModelMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CareLevel",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Temparament",
                table: "Animal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareLevel",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Temparament",
                table: "Animal");
        }
    }
}
