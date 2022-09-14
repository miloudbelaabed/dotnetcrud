using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipesApi.Migrations
{
    public partial class diplomespecialite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diplomes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeDiplome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialiteId = table.Column<int>(type: "int", nullable: false),
                    Diplomaid = table.Column<int>(type: "int", nullable: true),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diplomes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Diplomes_Diplomes_Diplomaid",
                        column: x => x.Diplomaid,
                        principalTable: "Diplomes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diplomes_Diplomaid",
                table: "Diplomes",
                column: "Diplomaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diplomes");
        }
    }
}
