using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuizQuestionsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionsId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizzesId",
                table: "QuizQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions");

            migrationBuilder.RenameTable(
                name: "QuizQuestions",
                newName: "QuestionQuiz");

            migrationBuilder.RenameIndex(
                name: "IX_QuizQuestions_QuizzesId",
                table: "QuestionQuiz",
                newName: "IX_QuestionQuiz_QuizzesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionQuiz",
                table: "QuestionQuiz",
                columns: new[] { "QuestionsId", "QuizzesId" });

            migrationBuilder.CreateTable(
                name: "QuizQuestion",
                columns: table => new
                {
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestion", x => new { x.QuizId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuestionId",
                table: "QuizQuestion",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsId",
                table: "QuestionQuiz",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionQuiz_Quizzes_QuizzesId",
                table: "QuestionQuiz",
                column: "QuizzesId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Questions_QuestionsId",
                table: "QuestionQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionQuiz_Quizzes_QuizzesId",
                table: "QuestionQuiz");

            migrationBuilder.DropTable(
                name: "QuizQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionQuiz",
                table: "QuestionQuiz");

            migrationBuilder.RenameTable(
                name: "QuestionQuiz",
                newName: "QuizQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionQuiz_QuizzesId",
                table: "QuizQuestions",
                newName: "IX_QuizQuestions_QuizzesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizQuestions",
                table: "QuizQuestions",
                columns: new[] { "QuestionsId", "QuizzesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Questions_QuestionsId",
                table: "QuizQuestions",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quizzes_QuizzesId",
                table: "QuizQuestions",
                column: "QuizzesId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
