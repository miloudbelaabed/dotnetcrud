using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesApi.Migrations
{
    public partial class updatethedb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diplomes_Diplomes_Diplomaid",
                table: "Diplomes");

            migrationBuilder.DropIndex(
                name: "IX_Diplomes_Diplomaid",
                table: "Diplomes");

            migrationBuilder.DropColumn(
                name: "Diplomaid",
                table: "Diplomes");

            migrationBuilder.CreateIndex(
                name: "IX_Diplomes_SpecialiteId",
                table: "Diplomes",
                column: "SpecialiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomes_Specialities_SpecialiteId",
                table: "Diplomes",
                column: "SpecialiteId",
                principalTable: "Specialities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diplomes_Specialities_SpecialiteId",
                table: "Diplomes");

            migrationBuilder.DropIndex(
                name: "IX_Diplomes_SpecialiteId",
                table: "Diplomes");

            migrationBuilder.AddColumn<int>(
                name: "Diplomaid",
                table: "Diplomes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diplomes_Diplomaid",
                table: "Diplomes",
                column: "Diplomaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Diplomes_Diplomes_Diplomaid",
                table: "Diplomes",
                column: "Diplomaid",
                principalTable: "Diplomes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
