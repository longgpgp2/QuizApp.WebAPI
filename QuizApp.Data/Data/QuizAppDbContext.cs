using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Models;
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

    public DbSet<UserQuiz> QuizQuestions { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users", CoreConstants.Schemas.Security);
        builder.Entity<Role>().ToTable("Roles", CoreConstants.Schemas.Security);
        builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", CoreConstants.Schemas.Security);
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", CoreConstants.Schemas.Security);
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", CoreConstants.Schemas.Security);
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", CoreConstants.Schemas.Security);
        builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", CoreConstants.Schemas.Security);

        builder.Entity<Question>().ToTable("Questions");
        builder.Entity<Answer>().ToTable("Answers");
        builder.Entity<UserQuiz>().ToTable("UserQuizzes");
        builder.Entity<UserAnswer>().ToTable("UserAnswers");
        builder.Entity<Quiz>().ToTable("Quizzes");
        builder.Entity<QuizQuestion>().ToTable("QuizQuestions");
        
        builder.Entity<Quiz>()
                .Navigation(q => q.QuizQuestions)
                .AutoInclude();

        builder.Entity<Question>()
            .Navigation(q => q.Answers)
            .AutoInclude();

        builder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        builder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);

        builder.Entity<UserAnswer>()
            .HasKey(ua => new { ua.Id, ua.UserQuizId, ua.QuestionId, ua.AnswerId });

        builder.Entity<QuizQuestion>()
            .HasKey(x => new { x.QuizId, x.QuestionId });

        builder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

        SeedData.Seed(builder);
    }


}
