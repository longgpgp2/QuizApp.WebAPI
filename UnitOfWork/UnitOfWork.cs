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


    private Repository<UserAnswer>? _userAnswerRepository;
    public Repository<UserAnswer> UserAnswerRepository => _userAnswerRepository ??= new Repository<UserAnswer>(_context);

    private Repository<UserQuiz>? _userQuizRepository;
    public Repository<UserQuiz> UserQuizRepository => _userQuizRepository ??= new Repository<UserQuiz>(_context);

    public UnitOfWork(QuizAppDbContext context)
    {
        _context = context;
    }





    private Repository<User>? _userRepository;
    public Repository<User> UserRepository => _userRepository ??= new Repository<User>(_context);


    private Repository<Role>? _roleRepository;
    public Repository<Role> RoleRepository => _roleRepository ??= new Repository<Role>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public IGenericRepository<T> GenericRepository<T>() where T : BaseEntity
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
        throw new NotImplementedException();
    }
}
