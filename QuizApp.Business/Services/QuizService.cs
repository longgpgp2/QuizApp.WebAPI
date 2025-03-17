using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp.Business.Services;
using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.QuizViews;
using QuizApp.Data.Models;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Services;

public class QuizService : BaseService<Quiz>, IQuizService
{
    private readonly IUserService _userService;
    public QuizService(IUnitOfWork unitOfWork, ILogger<QuizService> logger, IUserService userService, IMapper mapper) : base(unitOfWork, logger, mapper)
    {
        _userService = userService;
    }


    public async Task<QuizPrepareInfoViewModel?> PrepareQuizForUserAsync(PrepareQuizViewModel prepareQuizViewModel)
    {
        User user = await _userService.GetByIdAsync(prepareQuizViewModel.UserId)
            ?? throw new ResourceNotFoundException("User not found");
        UserQuiz userQuiz = await _unitOfWork.UserQuizRepository.GetQuery()
            .FirstOrDefaultAsync(uq => uq.UserId == user.Id && uq.QuizCode == prepareQuizViewModel.QuizCode)
            ?? throw new ResourceNotFoundException("UserQuiz not found");
        Quiz quiz = await GetByIdAsync(prepareQuizViewModel.QuizId)
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
        User user = await _userService.GetByIdAsync(model.UserId)
            ?? throw new ResourceNotFoundException("User not found");
        List<QuestionForTestViewModel> questions = (await GetQuestionsAsync(quiz))
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
        questions.ForEach(q=>System.Console.WriteLine("+++++++++++++++++++++++++++" + q.Content));
        _logger.LogInformation("User {0} is taking quiz {1} with question {3}", user.Id, quiz.Id, questions[0]);

        return new QuizForTestViewModel
        {
            Id = Guid.NewGuid(),
            Title = quiz.Title,
            Description = quiz.Description,
            Questions = questions,
            QuizCode = model.QuizCode,
            StartTime = DateTime.Now,
            Duration = quiz.Duration,
        };
    }

    public async Task<bool> SubmitQuizAsync(QuizSubmissionViewModel model)
    {
        User user = await _userService.GetByIdAsync(model.UserId)
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
        Quiz quiz = await base.GetByIdAsync(userQuiz.QuizId)
            ?? throw new ResourceNotFoundException("Quiz not found");

        List<AnswerForTestViewModel> correctAnswers = userQuiz.UserAnswers
            .Where(ua => ua.IsCorrect)
            .Select(ua => new AnswerForTestViewModel
            {
                Id = ua.AnswerId,
                Content = _unitOfWork.AnswerRepository
                    .GetQuery().FirstOrDefault(a => a.Id == ua.AnswerId)?.Content ?? ""
            }).ToList();
        List<Question> questions = await GetQuestionsAsync(quiz);

        List<QuestionForTestViewModel> totalQuestions = questions.Select(q => new QuestionForTestViewModel
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

    private async Task<List<Question>> GetQuestionsAsync(Quiz quiz)
    {
        return await _unitOfWork.QuestionRepository.GetQuery()
            .Where(q => quiz.QuizQuestions.Select(qq => qq.QuestionId).Contains(q.Id))
            .ToListAsync();
    }

    public async Task<int> AddAsync(QuizCreateViewModel quizCreateViewModel)
    {
        if (quizCreateViewModel == null)
        {
            throw new ArgumentNullException(nameof(quizCreateViewModel));
        }
        var quiz = new Quiz
        {
            Id = Guid.NewGuid(),
            Title = quizCreateViewModel.Title,
            Description = quizCreateViewModel.Description ?? "",
            Duration = quizCreateViewModel.Duration,
            IsActive = quizCreateViewModel.IsActive
        };
        quizCreateViewModel.QuestionIdWithOrders.ToList().ForEach(q =>
        {
            var question = _unitOfWork.QuestionRepository.GetQuery().FirstOrDefault(qe => qe.Id == q.QuestionId);
            if (question != null)
            {
                _unitOfWork.QuizQuestionRepository.Add(new QuizQuestion
                {
                    QuizId = quiz.Id,
                    QuestionId = question.Id,
                    Order = q.Order
                });
            }
            else throw new ArgumentNullException(nameof(QuizQuestion));
        });
        _unitOfWork.QuizRepository.Add(quiz);
        return await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, QuizEditViewModel quizEditViewModel)
    {
        if (quizEditViewModel == null)
        {
            throw new ArgumentNullException("QuizEditViewModel is required." + nameof(quizEditViewModel));
        }

        var existingQuiz = await GetByIdAsync(id);

        if (existingQuiz == null)
        {
            throw new ArgumentNullException($"Quiz with Id-{id} not found.");
        }

        existingQuiz.Title = quizEditViewModel.Title ?? existingQuiz.Title;
        existingQuiz.Description = quizEditViewModel.Description ?? existingQuiz.Description;
        existingQuiz.Duration = quizEditViewModel.Duration ?? existingQuiz.Duration;
        existingQuiz.IsActive = quizEditViewModel.IsActive ?? existingQuiz.IsActive;

        var updatedQuestionIds = quizEditViewModel.QuestionIdWithOrders
            .Select(q => q.QuestionId)
            .ToList();

        var questionsToRemove = existingQuiz.QuizQuestions
            .Where(q => !updatedQuestionIds.Contains(q.QuestionId))
            .ToList();

        foreach (var question in questionsToRemove)
        {
            existingQuiz.QuizQuestions.Remove(question);
        }

        foreach (var questionOrder in quizEditViewModel.QuestionIdWithOrders)
        {
            var existingQuizQuestion = existingQuiz.QuizQuestions
                .FirstOrDefault(q => q.QuestionId == questionOrder.QuestionId);

            if (existingQuizQuestion != null)
            {
                existingQuizQuestion.Order = questionOrder.Order;
            }
            else
            {
                var newQuizQuestion = new QuizQuestion
                {
                    QuizId = id,
                    QuestionId = questionOrder.QuestionId,
                    Order = questionOrder.Order
                };
                existingQuiz.QuizQuestions.Add(newQuizQuestion);
            }
        }

        _unitOfWork.QuizRepository.Update(existingQuiz);
        return await _unitOfWork.SaveChangesAsync() > 0;

    }

    public async Task<bool> AddQuestionToQuiz(QuizQuestionCreateViewModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException("Model is required." + nameof(model));
        }

        var existingQuiz = await GetByIdAsync(model.QuizId);

        if (existingQuiz == null)
        {
            throw new ArgumentNullException($"Quiz with Id-{model.QuizId} not found.");
        }

        var existingQuestion = await _unitOfWork.QuestionRepository
        .GetQuery()
        .Where(q => q.Id == model.QuestionId)
        .FirstOrDefaultAsync();

        if (existingQuestion == null)
        {
            throw new ArgumentNullException($"Question with Id-{model.QuestionId} not found.");
        }

        if (existingQuiz.QuizQuestions.FirstOrDefault(q => q.Equals(existingQuestion)) != null)
        {
            throw new InvalidOperationException($"Question with Id-{model.QuestionId} is already contained in Quiz with Id-{model.QuizId}.");
        }

        existingQuiz.QuizQuestions.Add(new QuizQuestion
        {
            QuestionId = model.QuestionId,
            QuizId = model.QuizId,
            Order = model.Order
        });

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
    public async Task<bool> DeleteQuestionFromQuizAsync(Guid quizId, Guid questionId)
    {
        Quiz? existingQuiz = await GetByIdAsync(quizId);

        if (existingQuiz == null)
        {
            throw new ArgumentNullException($"Quiz with Id-{quizId} not found.");
        }
        var quizQuestionToRemove = existingQuiz.QuizQuestions.FirstOrDefault(qq => qq.QuestionId == questionId);
        if (quizQuestionToRemove != null)
        {
            existingQuiz.QuizQuestions.Remove(quizQuestionToRemove);
        }
        else
        {
            throw new ArgumentNullException($"Question with Id-{questionId} not found.");
        }

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}
