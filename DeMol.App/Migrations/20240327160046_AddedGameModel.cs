using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeMol.App.Migrations
{
    /// <inheritdoc />
    public partial class AddedGameModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "VotingRounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ContributedPrizeMoney",
                table: "Candidates",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Candidates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<int>(type: "int", nullable: false),
                    PrizeMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_User_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VotingRounds_GameId",
                table: "VotingRounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_GameId",
                table: "Candidates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerId",
                table: "Games",
                column: "WinnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Games_GameId",
                table: "Candidates",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VotingRounds_Games_GameId",
                table: "VotingRounds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Games_GameId",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_VotingRounds_Games_GameId",
                table: "VotingRounds");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_VotingRounds_GameId",
                table: "VotingRounds");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_GameId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "VotingRounds");

            migrationBuilder.DropColumn(
                name: "ContributedPrizeMoney",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Candidates");
        }
    }
}
