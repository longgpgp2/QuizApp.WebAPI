﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizApp.WebAPI.Data;

#nullable disable

namespace QuizApp.Data.Migrations
{
    [DbContext(typeof(QuizAppDbContext))]
    [Migration("20250316162918_RenameDbTables")]
    partial class RenameDbTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Security");
                });

            modelBuilder.Entity("QuizApp.Data.Models.QuizQuestion", b =>
                {
                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("QuizId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuizQuestions", (string)null);
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999991"),
                            Content = "Paris",
                            IsActive = true,
                            IsCorrect = true,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777777")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999992"),
                            Content = "London",
                            IsActive = true,
                            IsCorrect = false,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777777")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999993"),
                            Content = "Mars",
                            IsActive = true,
                            IsCorrect = true,
                            IsDeleted = false,
                            QuestionId = new Guid("88888888-8888-8888-8888-888888888888")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999994"),
                            Content = "Venus",
                            IsActive = true,
                            IsCorrect = false,
                            IsDeleted = false,
                            QuestionId = new Guid("88888888-8888-8888-8888-888888888888")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999995"),
                            Content = "False",
                            IsActive = true,
                            IsCorrect = true,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777778")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999996"),
                            Content = "True",
                            IsActive = true,
                            IsCorrect = false,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777778")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999997"),
                            Content = "Blue Whale",
                            IsActive = true,
                            IsCorrect = true,
                            IsDeleted = false,
                            QuestionId = new Guid("88888888-8888-8888-8888-888888888889")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999998"),
                            Content = "Elephant",
                            IsActive = true,
                            IsCorrect = false,
                            IsDeleted = false,
                            QuestionId = new Guid("88888888-8888-8888-8888-888888888889")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-999999999999"),
                            Content = "4",
                            IsActive = true,
                            IsCorrect = true,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777779")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-9999999999a0"),
                            Content = "5",
                            IsActive = true,
                            IsCorrect = false,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777779")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-9999999999a1"),
                            Content = "6",
                            IsActive = true,
                            IsCorrect = false,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777779")
                        },
                        new
                        {
                            Id = new Guid("99999999-9999-9999-9999-9999999999a2"),
                            Content = "7",
                            IsActive = true,
                            IsCorrect = false,
                            IsDeleted = false,
                            QuestionId = new Guid("77777777-7777-7777-7777-777777777779")
                        });
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777777"),
                            Content = "What is the capital of France?",
                            IsActive = true,
                            IsDeleted = false,
                            QuestionType = "MultipleChoice"
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888888"),
                            Content = "Which planet is known as the 'Red Planet'?",
                            IsActive = true,
                            IsDeleted = false,
                            QuestionType = "MultipleChoice"
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777778"),
                            Content = "The Earth is flat.",
                            IsActive = true,
                            IsDeleted = false,
                            QuestionType = "TrueFalse"
                        },
                        new
                        {
                            Id = new Guid("88888888-8888-8888-8888-888888888889"),
                            Content = "What is the largest mammal?",
                            IsActive = true,
                            IsDeleted = false,
                            QuestionType = "MultipleChoice"
                        },
                        new
                        {
                            Id = new Guid("77777777-7777-7777-7777-777777777779"),
                            Content = "What is 2 + 2?",
                            IsActive = true,
                            IsDeleted = false,
                            QuestionType = "MultipleChoice"
                        });
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ThumbnailUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Quizzes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555555"),
                            Description = "This is a general knowledge quiz",
                            Duration = 300,
                            IsActive = true,
                            IsDeleted = false,
                            ThumbnailUrl = "https://example.com/quiz1.jpg",
                            Title = "Quiz 1: General Knowledge"
                        },
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666666"),
                            Description = "Test your knowledge of ancient Rome.",
                            Duration = 600,
                            IsActive = true,
                            IsDeleted = false,
                            ThumbnailUrl = "https://example.com/quiz2.jpg",
                            Title = "Quiz 2: History of Rome"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555556"),
                            Description = "Challenge your math skills.",
                            Duration = 450,
                            IsActive = true,
                            IsDeleted = false,
                            ThumbnailUrl = "https://example.com/quiz3.jpg",
                            Title = "Quiz 3: Math Puzzles"
                        },
                        new
                        {
                            Id = new Guid("66666666-6666-6666-6666-666666666667"),
                            Description = "Test your knowledge of classic books.",
                            Duration = 720,
                            IsActive = true,
                            IsDeleted = false,
                            ThumbnailUrl = "https://example.com/quiz4.jpg",
                            Title = "Quiz 4: Literature Classics"
                        },
                        new
                        {
                            Id = new Guid("55555555-5555-5555-5555-555555555557"),
                            Description = "Learn basic computer science concepts.",
                            Duration = 480,
                            IsActive = true,
                            IsDeleted = false,
                            ThumbnailUrl = "https://example.com/quiz5.jpg",
                            Title = "Quiz 5: Computer Science"
                        });
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "Security");

                    b.HasData(
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111111"),
                            Description = "Administrator role",
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222222"),
                            Description = "Regular user role",
                            IsActive = true,
                            IsDeleted = false,
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111112"),
                            Description = "Quiz moderator role",
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Moderator",
                            NormalizedName = "MODERATOR"
                        },
                        new
                        {
                            Id = new Guid("22222222-2222-2222-2222-222222222223"),
                            Description = "Guest user role",
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Guest",
                            NormalizedName = "GUEST"
                        },
                        new
                        {
                            Id = new Guid("11111111-1111-1111-1111-111111111113"),
                            Description = "Tester user role",
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Tester",
                            NormalizedName = "TESTER"
                        });
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "Security");
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.UserAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserQuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.HasKey("Id", "UserQuizId", "QuestionId", "AnswerId");

                    b.HasIndex("UserQuizId");

                    b.ToTable("UserAnswers", (string)null);
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.UserQuiz", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuizCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuizId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("UserQuizzes", (string)null);
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser", "Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizApp.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizApp.Data.Models.QuizQuestion", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizApp.WebAPI.Models.Quiz", "Quiz")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Answer", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Quiz", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.Question", null)
                        .WithMany("Quizzes")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.UserAnswer", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.UserQuiz", null)
                        .WithMany("UserAnswers")
                        .HasForeignKey("UserQuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.UserQuiz", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.Quiz", null)
                        .WithMany("UserQuizzes")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizApp.WebAPI.Models.User", null)
                        .WithMany("UserQuizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("QuizApp.WebAPI.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuizApp.WebAPI.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.Quiz", b =>
                {
                    b.Navigation("QuizQuestions");

                    b.Navigation("UserQuizzes");
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.User", b =>
                {
                    b.Navigation("UserQuizzes");
                });

            modelBuilder.Entity("QuizApp.WebAPI.Models.UserQuiz", b =>
                {
                    b.Navigation("UserAnswers");
                });
#pragma warning restore 612, 618
        }
    }
}
