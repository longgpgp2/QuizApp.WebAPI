using System;
using Microsoft.Extensions.Logging;
using QuizApp.Business.Services;
using QuizApp.Business.ViewModels;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Services;

public interface IQuizService : IBaseService<Quiz>
{

}

public class QuizService : BaseService<Quiz>, IQuizService
{
    private readonly IUserService _userService;
    public QuizService(IUnitOfWork unitOfWork, ILogger<QuizService> logger, IUserService userService) : base(unitOfWork, logger)
    {
        _userService = userService;
    }


    public async Task<QuizPrepareInfoViewModel?> PrepareQuizForUserAsync(PrepareQuizViewModel prepareQuizViewModel)
    {
        User user = await _userService.GetCurrentLoggedInUserAsync()
            ?? throw new ResourceNotFoundException("User not found");
        UserQuiz userQuiz = _unitOfWork.UserQuizRepository.GetQuery()
            .FirstOrDefault(uq => uq.UserId == user.Id && uq.QuizCode == prepareQuizViewModel.QuizCode)
            ?? throw new ResourceNotFoundException("UserQuiz not found");
        Quiz quiz = await GetByIdAsync(userQuiz.QuizId)
            ?? throw new ResourceNotFoundException("Quiz not found");
        UserViewModel userView = _userService.GetUserViewModel(user);
        _logger.LogInformation("User {0} is preparing for quiz {1}", userView.Id, quiz.Id);
        return new QuizPrepareInfoViewModel
        {
            Id = Guid.NewGuid(),
            Title = quiz.Title,
            Description = quiz.Description,
            QuizCode = prepareQuizViewModel.QuizCode,
            ThumbnailUrl = quiz.ThumbnailUrl,
            Duration = 10,
            User = userView
        };
    }

    public async Task<QuizForTestViewModel> TakeQuizAsync(TakeQuizViewModel model)
    {
        Quiz quiz = await GetByIdAsync(model.QuizId)
            ?? throw new ResourceNotFoundException("Quiz not found");
        User user = await _userService.GetCurrentLoggedInUserAsync()
            ?? throw new ResourceNotFoundException("User not found");
        List<QuestionForTestViewModel> questions = quiz.Questions
            .Select(q => new QuestionForTestViewModel
            {
                Id = q.Id,
                Content = q.Content,
                Answers = q.Answers.Select(a => new AnswerForTestViewModel
                {
                    Id = a.Id,
                    Content = a.Content
                }).ToList(),
                QuestionType = q.QuestionType
            }).ToList();

        UserQuiz userQuiz = new UserQuiz
        {
            UserId = user.Id,
            QuizId = quiz.Id,
            QuizCode = Guid.NewGuid().ToString()
        };
        _logger.LogInformation("User {0} is taking quiz {1}", user.Id, quiz.Id);

        return new QuizForTestViewModel
        {
            Id = Guid.NewGuid(),
            Title = quiz.Title,
            Description = quiz.Description,
            Questions = questions,
            QuizCode = userQuiz.QuizCode,
            StartTime = DateTime.Now,
            Duration = quiz.Duration,
        };
    }

    public async Task<bool> SubmitQuizAsync(QuizSubmissionViewModel model)
    {
        User user = await _userService.GetCurrentLoggedInUserAsync()
            ?? throw new ResourceNotFoundException("User not found");
        Guid userQuizId = Guid.NewGuid();
        UserQuiz userQuiz = new UserQuiz
        {
            Id = userQuizId,
            UserId = user.Id,
            QuizId = model.QuizId,
            QuizCode = Guid.NewGuid().ToString(),
            StartedAt = model.StartTime,
            FinishedAt = DateTime.Now,
            UserAnswers = model.UserAnswers.Select(ua => new UserAnswer
            {
                Id = Guid.NewGuid(),
                UserQuizId = userQuizId,
                QuestionId = ua.QuestionId,
                AnswerId = ua.AnswerId,
                IsCorrect = _unitOfWork.AnswerRepository
                    .GetQuery().FirstOrDefault(a => a.Id == ua.AnswerId)?.IsCorrect ?? false,
            }).ToList()
        };
        _unitOfWork.UserQuizRepository.Add(userQuiz);
        _logger.LogInformation("User {0} submitted quiz {1}", user.Id, model.QuizId);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<QuizResultViewModel> GetQuizResultAsync(GetQuizResultViewModel model)
    {
        User user = await _userService.GetCurrentLoggedInUserAsync()
            ?? throw new ResourceNotFoundException("User not found");
        UserQuiz userQuiz = _unitOfWork.UserQuizRepository
            .GetQuery()
            .LastOrDefault(uq => uq.QuizId == model.QuizId && uq.UserId == user.Id)
            ?? throw new ResourceNotFoundException("UserQuiz not found");
        Quiz quiz = await GetByIdAsync(userQuiz.QuizId)
            ?? throw new ResourceNotFoundException("Quiz not found");

        List<AnswerForTestViewModel> correctAnswers = userQuiz.UserAnswers
            .Where(ua => ua.IsCorrect)
            .Select(ua => new AnswerForTestViewModel
            {
                Id = ua.AnswerId,
                Content = _unitOfWork.AnswerRepository
                    .GetQuery().FirstOrDefault(a => a.Id == ua.AnswerId)?.Content ?? ""
            }).ToList();

        List<QuestionForTestViewModel> totalQuestions = quiz.Questions.Select(q => new QuestionForTestViewModel
        {
            Id = q.Id,
            Content = q.Content,
            Answers = q.Answers.Select(a => new AnswerForTestViewModel
            {
                Id = a.Id,
                Content = a.Content,
            }).ToList(),
            QuestionType = q.QuestionType
        }).ToList();
        _logger.LogInformation("User {0} retrieved quiz {1} result", user.Id, model.QuizId);

        return new QuizResultViewModel
        {
            QuizId = quiz.Id,
            UserId = user.Id,
            CorrectAnswers = correctAnswers,
            TotalQuestions = totalQuestions,
            Score = (correctAnswers.Count / totalQuestions.Count) * 100
        };
    }

}
