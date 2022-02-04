using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fish.Migrations
{
    public partial class AnimalPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "maxSize",
                table: "Animal",
                newName: "MaxSize");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Animal",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "MaxSize",
                table: "Animal",
                newName: "maxSize");
        }
    }
}
