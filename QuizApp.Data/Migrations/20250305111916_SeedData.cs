using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApp.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    QuestionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizzesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => new { x.QuestionsId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserQuizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuizCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserQuizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserQuizzes_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserQuizzes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RolesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserQuizId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => new { x.Id, x.UserQuizId, x.QuestionId, x.AnswerId });
                    table.ForeignKey(
                        name: "FK_UserAnswers_UserQuizzes_UserQuizId",
                        column: x => x.UserQuizId,
                        principalTable: "UserQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "IsDeleted", "QuestionType" },
                values: new object[,]
                {
                    { new Guid("77777777-7777-7777-7777-777777777777"), "What is the capital of France?", false, "MultipleChoice" },
                    { new Guid("77777777-7777-7777-7777-777777777778"), "The Earth is flat.", false, "TrueFalse" },
                    { new Guid("77777777-7777-7777-7777-777777777779"), "What is 2 + 2?", false, "MultipleChoice" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Which planet is known as the 'Red Planet'?", false, "MultipleChoice" },
                    { new Guid("88888888-8888-8888-8888-888888888889"), "What is the largest mammal?", false, "MultipleChoice" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Description", "Duration", "IsDeleted", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-555555555555"), "This is a general knowledge quiz", 300, false, "https://example.com/quiz1.jpg", "Quiz 1: General Knowledge" },
                    { new Guid("55555555-5555-5555-5555-555555555556"), "Challenge your math skills.", 450, false, "https://example.com/quiz3.jpg", "Quiz 3: Math Puzzles" },
                    { new Guid("55555555-5555-5555-5555-555555555557"), "Learn basic computer science concepts.", 480, false, "https://example.com/quiz5.jpg", "Quiz 5: Computer Science" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Test your knowledge of ancient Rome.", 600, false, "https://example.com/quiz2.jpg", "Quiz 2: History of Rome" },
                    { new Guid("66666666-6666-6666-6666-666666666667"), "Test your knowledge of classic books.", 720, false, "https://example.com/quiz4.jpg", "Quiz 4: Literature Classics" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "IsActive", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "Administrator role", true, "Admin", "ADMIN" },
                    { new Guid("11111111-1111-1111-1111-111111111112"), null, "Quiz moderator role", true, "Moderator", "MODERATOR" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), null, "Tester user role", true, "Tester", "TESTER" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "Regular user role", true, "User", "USER" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), null, "Guest user role", true, "Guest", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Content", "IsCorrect", "IsDeleted", "QuestionId" },
                values: new object[,]
                {
                    { new Guid("99999999-9999-9999-9999-999999999991"), "Paris", true, false, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("99999999-9999-9999-9999-999999999992"), "London", false, false, new Guid("77777777-7777-7777-7777-777777777777") },
                    { new Guid("99999999-9999-9999-9999-999999999993"), "Mars", true, false, new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("99999999-9999-9999-9999-999999999994"), "Venus", false, false, new Guid("88888888-8888-8888-8888-888888888888") },
                    { new Guid("99999999-9999-9999-9999-999999999995"), "False", true, false, new Guid("77777777-7777-7777-7777-777777777778") },
                    { new Guid("99999999-9999-9999-9999-999999999996"), "True", false, false, new Guid("77777777-7777-7777-7777-777777777778") },
                    { new Guid("99999999-9999-9999-9999-999999999997"), "Blue Whale", true, false, new Guid("88888888-8888-8888-8888-888888888889") },
                    { new Guid("99999999-9999-9999-9999-999999999998"), "Elephant", false, false, new Guid("88888888-8888-8888-8888-888888888889") },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "4", true, false, new Guid("77777777-7777-7777-7777-777777777779") },
                    { new Guid("99999999-9999-9999-9999-9999999999a0"), "5", false, false, new Guid("77777777-7777-7777-7777-777777777779") },
                    { new Guid("99999999-9999-9999-9999-9999999999a1"), "6", false, false, new Guid("77777777-7777-7777-7777-777777777779") },
                    { new Guid("99999999-9999-9999-9999-9999999999a2"), "7", false, false, new Guid("77777777-7777-7777-7777-777777777779") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizzesId",
                table: "QuizQuestions",
                column: "QuizzesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_UserQuizId",
                table: "UserAnswers",
                column: "UserQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizzes_QuizId",
                table: "UserQuizzes",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_UserQuizzes_UserId",
                table: "UserQuizzes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UsersId",
                table: "UserRoles",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "UserQuizzes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
