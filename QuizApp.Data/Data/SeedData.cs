using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Models;
using Microsoft.AspNetCore.Identity;

public static class SeedData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Roles
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                Description = "Administrator role",
                IsActive = true
            },
            new Role
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "User",
                NormalizedName = "USER",
                Description = "Regular user role",
                IsActive = true
            },
            new Role
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Name = "Moderator",
                NormalizedName = "MODERATOR",
                Description = "Quiz moderator role",
                IsActive = true
            },
            new Role
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222223"),
                Name = "Guest",
                NormalizedName = "GUEST",
                Description = "Guest user role",
                IsActive = true
            },
            new Role
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                Name = "Tester",
                NormalizedName = "TESTER",
                Description = "Tester user role",
                IsActive = true
            }
        );

        // Quizzes
        modelBuilder.Entity<Quiz>().HasData(
            new Quiz
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Title = "Quiz 1: General Knowledge",
                Description = "This is a general knowledge quiz",
                Duration = 300,
                ThumbnailUrl = "https://example.com/quiz1.jpg"
            },
            new Quiz
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Title = "Quiz 2: History of Rome",
                Description = "Test your knowledge of ancient Rome.",
                Duration = 600,
                ThumbnailUrl = "https://example.com/quiz2.jpg"
            },
            new Quiz
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555556"),
                Title = "Quiz 3: Math Puzzles",
                Description = "Challenge your math skills.",
                Duration = 450,
                ThumbnailUrl = "https://example.com/quiz3.jpg"
            },
            new Quiz
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666667"),
                Title = "Quiz 4: Literature Classics",
                Description = "Test your knowledge of classic books.",
                Duration = 720,
                ThumbnailUrl = "https://example.com/quiz4.jpg"
            },
             new Quiz
             {
                 Id = Guid.Parse("55555555-5555-5555-5555-555555555557"),
                 Title = "Quiz 5: Computer Science",
                 Description = "Learn basic computer science concepts.",
                 Duration = 480,
                 ThumbnailUrl = "https://example.com/quiz5.jpg"
             }
        );

        // Questions
        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                QuestionType = QuestionTypeEnum.MultipleChoice.ToString(),
                Content = "What is the capital of France?"
            },
            new Question
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                QuestionType = QuestionTypeEnum.MultipleChoice.ToString(),
                Content = "Which planet is known as the 'Red Planet'?"
            },
            new Question
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777778"),
                QuestionType = QuestionTypeEnum.TrueFalse.ToString(),
                Content = "The Earth is flat."
            },
            new Question
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888889"),
                QuestionType = QuestionTypeEnum.MultipleChoice.ToString(),
                Content = "What is the largest mammal?"
            },
            new Question
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777779"),
                QuestionType = QuestionTypeEnum.MultipleChoice.ToString(),
                Content = "What is 2 + 2?"
            }
        );

        modelBuilder.Entity<Answer>().HasData(
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999991"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777777"), Content = "Paris", IsCorrect = true },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999992"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777777"), Content = "London", IsCorrect = false },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999993"), QuestionId = Guid.Parse("88888888-8888-8888-8888-888888888888"), Content = "Mars", IsCorrect = true },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999994"), QuestionId = Guid.Parse("88888888-8888-8888-8888-888888888888"), Content = "Venus", IsCorrect = false },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999995"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777778"), Content = "False", IsCorrect = true },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999996"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777778"), Content = "True", IsCorrect = false },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999997"), QuestionId = Guid.Parse("88888888-8888-8888-8888-888888888889"), Content = "Blue Whale", IsCorrect = true },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999998"), QuestionId = Guid.Parse("88888888-8888-8888-8888-888888888889"), Content = "Elephant", IsCorrect = false },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-999999999999"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777779"), Content = "4", IsCorrect = true },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-9999999999A0"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777779"), Content = "5", IsCorrect = false },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-9999999999A1"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777779"), Content = "6", IsCorrect = false },
            new Answer { Id = Guid.Parse("99999999-9999-9999-9999-9999999999A2"), QuestionId = Guid.Parse("77777777-7777-7777-7777-777777777779"), Content = "7", IsCorrect = false }

        );
    }
}