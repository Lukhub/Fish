using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fish.Migrations
{
    public partial class FamilyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GenusId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenusForeignId = table.Column<int>(type: "INTEGER", nullable: true),
                    FamilyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genus_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Genus_Genus_GenusForeignId",
                        column: x => x.GenusForeignId,
                        principalTable: "Genus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genus_FamilyId",
                table: "Genus",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Genus_GenusForeignId",
                table: "Genus",
                column: "GenusForeignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genus");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}
