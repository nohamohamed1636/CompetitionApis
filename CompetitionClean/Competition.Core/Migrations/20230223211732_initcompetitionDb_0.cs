using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class initcompetitionDb_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolBranchId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FullMark = table.Column<double>(type: "float", nullable: true),
                    QuestionsCount = table.Column<int>(type: "int", nullable: false),
                    AnsweringDuration = table.Column<int>(type: "int", nullable: true),
                    publishFree = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaticDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    MultibleChoice = table.Column<bool>(type: "bit", nullable: false),
                    TrueFalse = table.Column<bool>(type: "bit", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true),
                    CorrectionMark = table.Column<double>(type: "float", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    AnswerDuration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionQuestions_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentHistoryId = table.Column<int>(type: "int", nullable: true),
                    Solved = table.Column<bool>(type: "bit", nullable: false),
                    StarDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Degree = table.Column<double>(type: "float", nullable: false),
                    PercentScore = table.Column<double>(type: "float", nullable: true),
                    ResultGrade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Absent = table.Column<bool>(type: "bit", nullable: false),
                    Opened = table.Column<bool>(type: "bit", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false),
                    Started = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionTargets_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionTargetId = table.Column<int>(type: "int", nullable: false),
                    CompetitonQuestionId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightAnswer = table.Column<bool>(type: "bit", nullable: true),
                    Mark = table.Column<double>(type: "float", nullable: true),
                    Corrected = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionAnswers_CompetitionQuestions_CompetitonQuestionId",
                        column: x => x.CompetitonQuestionId,
                        principalTable: "CompetitionQuestions",
                        principalColumn: "Id"
                        //,
                        //onDelete: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_CompetitionAnswers_CompetitionTargets_CompetitionTargetId",
                        column: x => x.CompetitionTargetId,
                        principalTable: "CompetitionTargets",
                        principalColumn: "Id"
                        //,
                        //onDelete: ReferentialAction.Cascade
                        );
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionAnswers_CompetitionTargetId",
                table: "CompetitionAnswers",
                column: "CompetitionTargetId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionAnswers_CompetitonQuestionId",
                table: "CompetitionAnswers",
                column: "CompetitonQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionQuestions_CompetitionId",
                table: "CompetitionQuestions",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionTargets_CompetitionId",
                table: "CompetitionTargets",
                column: "CompetitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetitionAnswers");

            migrationBuilder.DropTable(
                name: "CompetitionQuestions");

            migrationBuilder.DropTable(
                name: "CompetitionTargets");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
