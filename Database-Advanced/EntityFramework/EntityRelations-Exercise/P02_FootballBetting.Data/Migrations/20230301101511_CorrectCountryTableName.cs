using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_FootballBetting.Data.Migrations
{
    public partial class CorrectCountryTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Countrys_CountryId",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countrys",
                table: "Countrys");

            migrationBuilder.RenameTable(
                name: "Countrys",
                newName: "Countries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Towns_Countries_CountryId",
                table: "Towns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Countrys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countrys",
                table: "Countrys",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Towns_Countrys_CountryId",
                table: "Towns",
                column: "CountryId",
                principalTable: "Countrys",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
