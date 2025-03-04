using System;
using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Data;

public class QuizAppDbContext: DbContext
{
    public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options): base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }

    public DbSet<Quiz> Quizzes { get; set; }

    public DbSet<Answer> Answers { get; set; }

}


