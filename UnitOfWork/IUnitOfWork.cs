using System;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Repositories;

namespace QuizApp.WebAPI.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    QuizAppDbContext Context { get; }

    IGenericRepository<Quiz> QuizRepository { get; }

    IGenericRepository<Question> QuestionRepository { get; }

    IGenericRepository<Answer> AnswerRepository { get; }

    Repository<UserAnswer> UserAnswerRepository { get; }
    
    Repository<UserQuiz> UserQuizRepository { get; }

    Repository<User> UserRepository { get; }

    Repository<Role> RoleRepository { get; }

    
    Task<int> SaveChangesAsync();
    
    int SaveChanges();

    IGenericRepository<T> GenericRepository<T>() where T : BaseEntity;

    IRepository<T> Repository<T>() where T : class;

}