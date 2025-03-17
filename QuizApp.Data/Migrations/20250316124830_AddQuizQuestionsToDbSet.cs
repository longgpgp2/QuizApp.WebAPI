using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizQuestionsToDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserQuizzes_UserQuizId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizzes_AspNetUsers_UserId",
                table: "UserQuizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuizzes_Quizzes_QuizId",
                table: "UserQuizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuizzes",
                table: "UserQuizzes");

            migrationBuilder.RenameTable(
                name: "UserQuizzes",
                newName: "UserQuiz");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuizzes_UserId",
                table: "UserQuiz",
                newName: "IX_UserQuiz_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuizzes_QuizId",
                table: "UserQuiz",
                newName: "IX_UserQuiz_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuiz",
                table: "UserQuiz",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserQuiz_UserQuizId",
                table: "UserAnswers",
                column: "UserQuizId",
                principalTable: "UserQuiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuiz_AspNetUsers_UserId",
                table: "UserQuiz",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuiz_Quizzes_QuizId",
                table: "UserQuiz",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserQuiz_UserQuizId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuiz_AspNetUsers_UserId",
                table: "UserQuiz");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQuiz_Quizzes_QuizId",
                table: "UserQuiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserQuiz",
                table: "UserQuiz");

            migrationBuilder.RenameTable(
                name: "UserQuiz",
                newName: "UserQuizzes");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuiz_UserId",
                table: "UserQuizzes",
                newName: "IX_UserQuizzes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQuiz_QuizId",
                table: "UserQuizzes",
                newName: "IX_UserQuizzes_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserQuizzes",
                table: "UserQuizzes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserQuizzes_UserQuizId",
                table: "UserAnswers",
                column: "UserQuizId",
                principalTable: "UserQuizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizzes_AspNetUsers_UserId",
                table: "UserQuizzes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuizzes_Quizzes_QuizId",
                table: "UserQuizzes",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
