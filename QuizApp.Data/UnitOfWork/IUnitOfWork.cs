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

    IGenericRepository<Answer> AnswerRepository { get; }

    IGenericRepository<User> UserRepository { get; }

    IGenericRepository<Role> RoleRepository { get; }

    IRepository<UserAnswer> UserAnswerRepository { get; }

    IRepository<QuizQuestion> QuizQuestionRepository { get; }

    IRepository<UserQuiz> UserQuizRepository { get; }



    Task<int> SaveChangesAsync();

    int SaveChanges();

    IGenericRepository<T> GenericRepository<T>() where T : class, IBaseEntity;

    IRepository<T> Repository<T>() where T : class;

    Task BeginTransaction();

    Task CommitTransaction();

    Task RollbackTransaction();


}