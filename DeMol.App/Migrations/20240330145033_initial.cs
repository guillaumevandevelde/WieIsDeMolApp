using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeMol.App.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PrizeMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ContributedPrizeMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMol = table.Column<bool>(type: "bit", nullable: false),
                    IsWinner = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingRounds_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VotingRoundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_VotingRounds_VotingRoundId",
                        column: x => x.VotingRoundId,
                        principalTable: "VotingRounds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MoleVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoleVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoleVote_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoleVote_Vote_VoteId",
                        column: x => x.VoteId,
                        principalTable: "Vote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WinnerVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinnerVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WinnerVote_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WinnerVote_Vote_VoteId",
                        column: x => x.VoteId,
                        principalTable: "Vote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "PrizeMoney", "Year" },
                values: new object[] { 1, 0m, 2024 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContributedPrizeMoney", "GameId", "IsActive", "IsMol", "IsWinner", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, 0m, 1, true, false, false, "Bernard", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/bdm24nieuw-saho7d.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=ea28199490bd4cfb4d764ba5911db6f94f52415997f17b3ed256e048c38af881" },
                    { 2, 0m, 1, true, false, false, "Marta(coco)", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/mcdm24nieuw-sahovx.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=27a5ac56329b8ee476b7b687583a78e9893539d8685574f3e143531a93e8e0d1" },
                    { 3, 0m, 1, true, false, false, "Philippe", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/pdm24nieuw-sahp1j.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=c02d5fab06f14ca3982627b67c48b0c3055bed691e6dbf3d1fc953746429b47b" },
                    { 4, 0m, 1, true, false, false, "Senne", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/sdm24nieuw-sahp3m.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=ee19c47e877988a2b283fc72a0f555aaaca5ba432e55109ecb616557aadc35bb" },
                    { 5, 0m, 1, true, false, false, "Lynn", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/ldm24nieuw-sahoti.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=5ade24f01e60fca9ca7a404fe4318eb08ebce2bff20c499f09d20d41730c60c1" },
                    { 6, 0m, 1, true, false, false, "Stéphanie", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/sbdm24nieuw-sahp5a.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=6d07da5829f1f6620aec4ad33e4a8cb713ca95f1f13848c244c613076e548575" },
                    { 7, 0m, 1, true, false, false, "Charlotte", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/cdm24nieuw-sahomm.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=440250844d35d1571751fc27ebae8db86274e75d5ebbc2f7aff4c59f399566a6" },
                    { 8, 0m, 1, true, false, false, "Michaël", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/mdm24nieuw-sahoy0.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=d5961367e02cb4504d4798a44acd094671bed56bc5b14a2dfc3b968f31ab7343" },
                    { 9, 0m, 1, true, false, false, "Karolien", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/kdm24nieuw-sahora.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=af1491127e180258c741ec809cc848e284a5a7c00e2d2d0633c3a5e03465aebb" },
                    { 10, 0m, 1, false, false, false, "Gillian", "https://wmimages.goplay.be/styles/f3d8f28cbac6369d15c66e328ab3944d4bcd3510/meta/afvaller1roodscherm-savf4v.jpg?style=W3sianBlZyI6eyJxdWFsaXR5Ijo4NX19LHsicmVzaXplIjp7ImZpdCI6ImNvdmVyIiwid2lkdGgiOjE2MCwiaGVpZ2h0IjoxNjAsImdyYXZpdHkiOm51bGwsIndpdGhvdXRFbmxhcmdlbWVudCI6ZmFsc2V9fV0=&sign=96ec0857ab9ccbdb15371533ff4c6ee5e9444a4d595ea7a5db5e3a748c09aad2" }
                });

            migrationBuilder.InsertData(
                table: "VotingRounds",
                columns: new[] { "Id", "EndTime", "GameId", "Round", "StartTime" },
                values: new object[] { 1, new DateTime(2024, 3, 31, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2024, 3, 30, 15, 50, 32, 736, DateTimeKind.Local).AddTicks(2335) });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_GameId",
                table: "Candidates",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_MoleVote_CandidateId",
                table: "MoleVote",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_MoleVote_VoteId",
                table: "MoleVote",
                column: "VoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_VotingRoundId",
                table: "Vote",
                column: "VotingRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingRounds_GameId",
                table: "VotingRounds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_WinnerVote_CandidateId",
                table: "WinnerVote",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_WinnerVote_VoteId",
                table: "WinnerVote",
                column: "VoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoleVote");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WinnerVote");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "VotingRounds");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
