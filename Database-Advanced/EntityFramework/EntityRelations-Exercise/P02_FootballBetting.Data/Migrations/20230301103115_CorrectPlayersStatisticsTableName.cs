using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P02_FootballBetting.Data.Migrations
{
    public partial class CorrectPlayersStatisticsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_Games_GameId",
                table: "PlayerStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStatistics_Players_PlayerId",
                table: "PlayerStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerStatistics",
                table: "PlayerStatistics");

            migrationBuilder.RenameTable(
                name: "PlayerStatistics",
                newName: "PlayersStatistics");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerStatistics_GameId",
                table: "PlayersStatistics",
                newName: "IX_PlayersStatistics_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayersStatistics",
                table: "PlayersStatistics",
                columns: new[] { "PlayerId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersStatistics_Games_GameId",
                table: "PlayersStatistics",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayersStatistics_Players_PlayerId",
                table: "PlayersStatistics",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayersStatistics_Games_GameId",
                table: "PlayersStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayersStatistics_Players_PlayerId",
                table: "PlayersStatistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayersStatistics",
                table: "PlayersStatistics");

            migrationBuilder.RenameTable(
                name: "PlayersStatistics",
                newName: "PlayerStatistics");

            migrationBuilder.RenameIndex(
                name: "IX_PlayersStatistics_GameId",
                table: "PlayerStatistics",
                newName: "IX_PlayerStatistics_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerStatistics",
                table: "PlayerStatistics",
                columns: new[] { "PlayerId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_Games_GameId",
                table: "PlayerStatistics",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStatistics_Players_PlayerId",
                table: "PlayerStatistics",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
