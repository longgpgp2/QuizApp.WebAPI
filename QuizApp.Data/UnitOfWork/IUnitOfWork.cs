using System;
using QuizApp.Data.Models;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Repositories;

namespace QuizApp.WebAPI.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    QuizAppDbContext Context { get; }

    IGenericRepository<Quiz> QuizRepository { get; }

    IGenericRepository<Question> QuestionRepository { get; }

    IRepository<UserQuiz> UserQuizRepository { get; }

    IRepository<QuizQuestion> QuizQuestionRepository { get; }

    IRepository<UserAnswer> UserAnswerRepository { get; }

    IGenericRepository<User> UserRepository { get; }

    IGenericRepository<Role> RoleRepository { get; }

    IGenericRepository<Answer> AnswerRepository { get; }

    IGenericRepository<T> GenericRepository<T>() where T : class, IBaseEntity;

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IRepository<T> Repository<T>() where T : class;

    Task BeginTransactionAsync();

    Task CommitTransactionAsync();

    Task RollbackTransactionAsync();









}