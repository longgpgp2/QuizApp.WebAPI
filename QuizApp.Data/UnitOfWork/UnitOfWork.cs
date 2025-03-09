using QuizApp.Data.Models;
using QuizApp.WebAPI;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Repositories;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly QuizAppDbContext _context;

    private bool _disposed = false;

    public QuizAppDbContext Context => _context;

    private IGenericRepository<Quiz>? _quizRepository;
    public IGenericRepository<Quiz> QuizRepository => _quizRepository ??= new GenericRepository<Quiz>(_context);

    private IGenericRepository<Answer>? _answerRepository;
    public IGenericRepository<Answer> AnswerRepository => _answerRepository ??= new GenericRepository<Answer>(_context);

    private IGenericRepository<Question>? _questionRepository;
    public IGenericRepository<Question> QuestionRepository => _questionRepository ??= new GenericRepository<Question>(_context);

    private IGenericRepository<User>? _userRepository;
    public IGenericRepository<User> UserRepository => _userRepository ??= new GenericRepository<User>(_context);


    private IGenericRepository<Role>? _roleRepository;
    public IGenericRepository<Role> RoleRepository => _roleRepository ??= new GenericRepository<Role>(_context);

    private IRepository<UserAnswer>? _userAnswerRepository;
    public IRepository<UserAnswer> UserAnswerRepository => _userAnswerRepository ??= new Repository<UserAnswer>(_context);

    private IRepository<UserQuiz>? _userQuizRepository;
    public IRepository<UserQuiz> UserQuizRepository => _userQuizRepository ??= new Repository<UserQuiz>(_context);

    private IRepository<QuizQuestion>? _quizQuestionRepository;
    public IRepository<QuizQuestion> QuizQuestionRepository => _quizQuestionRepository ??= new Repository<QuizQuestion>(_context);

    public UnitOfWork(QuizAppDbContext context)
    {
        _context = context;
    }



    IRepository<QuizQuestion> IUnitOfWork.QuizQuestionRepository => QuizQuestionRepository;

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public IGenericRepository<T> GenericRepository<T>() where T : class, IBaseEntity
    {
        return new GenericRepository<T>(_context);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IRepository<T> Repository<T>() where T : class
    {
        return new Repository<T>(_context);
    }

    public async Task BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransaction()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}
