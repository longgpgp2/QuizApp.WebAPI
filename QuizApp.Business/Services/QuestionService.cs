using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp.Business.ViewModels.AnswerViews;
using QuizApp.Business.ViewModels.QuestionViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Services;

public class QuestionService : BaseService<Question>, IQuestionService
{
    public QuestionService(IUnitOfWork unitOfWork, ILogger<QuestionService> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
    {
    }

    public async Task<Question> AddAnswerToQuestionAsync(Question question, Answer answer)
    {
        if (question == null || answer == null)
        {
            throw new ArgumentNullException(nameof(question) + ", " + nameof(answer));
        }
        if (GetById(question.Id) == null)
        {
            throw new ArgumentNullException(nameof(question));
        }
        // TODO: begin transaction
        answer.QuestionId = question.Id;
        question.Answers.Add(answer);

        _unitOfWork.AnswerRepository.Add(answer);
        _unitOfWork.QuestionRepository.Update(question);

        await _unitOfWork.SaveChangesAsync();
        return question;
    }

    public async Task<int> AddAsync(QuestionCreateViewModel questionCreateViewModel)
    {
        Question questionModel = new Question
        {
            Id = Guid.NewGuid(),
            Answers = questionCreateViewModel.Answer.Select(a => _mapper.Map<Answer>(a)).ToList(),
            Content = questionCreateViewModel.Content,
            IsActive = questionCreateViewModel.IsActive,
            QuestionType = questionCreateViewModel.QuestionType.ToString(),
        };
        return await AddAsync(questionModel);
    }

    public async Task<Question> RemoveAnswerFromQuestionAsync(Question question, Answer answer)
    {
        if (question == null || answer == null)
        {
            throw new ArgumentNullException(nameof(question) + ", " + nameof(answer));
        }
        if (GetById(question.Id) == null || _unitOfWork.AnswerRepository.GetById(answer.Id) == null)
        {
            throw new ArgumentNullException(nameof(question) + ", " + nameof(answer));
        }
        // TODO: begin transaction
        answer.QuestionId = question.Id;
        question.Answers.Remove(answer);

        _unitOfWork.AnswerRepository.Delete(answer);
        _unitOfWork.QuestionRepository.Update(question);

        await _unitOfWork.SaveChangesAsync();
        return question;
    }

    public async Task<bool> UpdateAsync(Guid id, QuestionEditViewModel questionEditViewModel)
    {
        if (questionEditViewModel == null)
        {
            throw new ArgumentNullException(nameof(questionEditViewModel));
        }

        var existingQuestion = await _unitOfWork.QuestionRepository
            .GetQuery()
            .Where(q => q.Id == id)
            .Include(q => q.Answers)
            .FirstOrDefaultAsync();


        existingQuestion.Content = questionEditViewModel.Content ?? existingQuestion.Content;
        existingQuestion.IsActive = questionEditViewModel.IsActive ?? existingQuestion.IsActive;
        existingQuestion.QuestionType = questionEditViewModel.QuestionType.ToString() ?? existingQuestion.QuestionType;

        var updatedAnswerIds = questionEditViewModel.Answer.Where(a => a.Id != Guid.Empty).Select(a => a.Id).ToList();
        var existingAnswerIds = existingQuestion.Answers.Select(a => a.Id).ToList();

        var answersToRemove = existingQuestion.Answers.Where(a => !updatedAnswerIds.Contains(a.Id)).ToList();
        foreach (var answer in answersToRemove)
        {
            await RemoveAnswerFromQuestionAsync(existingQuestion, answer);
        }

        foreach (var answerVm in questionEditViewModel.Answer)
        {
            if (existingAnswerIds.Contains(answerVm.Id))
            {
                var existingAnswer = existingQuestion.Answers.First(a => a.Id == answerVm.Id);
                existingAnswer.Content = answerVm.Content;
                existingAnswer.IsCorrect = answerVm.IsCorrect;
            }
            else
            {
                var newAnswer = _mapper.Map<Answer>(answerVm);
                await AddAnswerToQuestionAsync(existingQuestion, newAnswer);
            }
        }

        _logger.LogInformation("Question with Id-{0} is updated", id);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }


}
