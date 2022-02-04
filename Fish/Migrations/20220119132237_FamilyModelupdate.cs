using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fish.Migrations
{
    public partial class FamilyModelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genus_Family_FamilyId",
                table: "Genus");

            migrationBuilder.DropForeignKey(
                name: "FK_Genus_Genus_GenusForeignId",
                table: "Genus");

            migrationBuilder.DropIndex(
                name: "IX_Genus_GenusForeignId",
                table: "Genus");

            migrationBuilder.DropColumn(
                name: "GenusForeignId",
                table: "Genus");

            migrationBuilder.DropColumn(
                name: "GenusId",
                table: "Genus");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyId",
                table: "Genus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Genus_Family_FamilyId",
                table: "Genus",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genus_Family_FamilyId",
                table: "Genus");

            migrationBuilder.AlterColumn<int>(
                name: "FamilyId",
                table: "Genus",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "GenusForeignId",
                table: "Genus",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenusId",
                table: "Genus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Genus_GenusForeignId",
                table: "Genus",
                column: "GenusForeignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genus_Family_FamilyId",
                table: "Genus",
                column: "FamilyId",
                principalTable: "Family",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genus_Genus_GenusForeignId",
                table: "Genus",
                column: "GenusForeignId",
                principalTable: "Genus",
                principalColumn: "Id");
        }
    }
}
