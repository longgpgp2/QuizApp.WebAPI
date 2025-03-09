using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Data;

public class QuizAppDbContext : IdentityDbContext<User, Role, Guid>
{
    public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }

    public DbSet<Quiz> Quizzes { get; set; }

    public DbSet<Answer> Answers { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserAnswer> UserAnswers { get; set; }

    public DbSet<UserQuiz> UserQuizzes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().ToTable("Users", CoreConstants.Schemas.Security);
        modelBuilder.Entity<Role>().ToTable("Roles", CoreConstants.Schemas.Security);
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", CoreConstants.Schemas.Security);
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", CoreConstants.Schemas.Security);
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", CoreConstants.Schemas.Security);
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", CoreConstants.Schemas.Security);
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", CoreConstants.Schemas.Security);

        modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<User>()
        .HasMany(s => s.Roles)
        .WithMany(r => r.Users)
        .UsingEntity(j => j.ToTable("UserRoles"));

        modelBuilder.Entity<UserAnswer>()
        .HasKey(ua => new { ua.Id, ua.UserQuizId, ua.QuestionId, ua.AnswerId });

        modelBuilder.Entity<Question>()
        .HasMany(q => q.Answers)
        .WithOne(a => a.Question)
        .HasForeignKey(a => a.QuestionId);

        modelBuilder.Entity<Quiz>()
        .HasMany(q => q.Questions)
        .WithMany(q => q.Quizzes)
        .UsingEntity(j => j.ToTable("QuizQuestions"));


        SeedData.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }


}
