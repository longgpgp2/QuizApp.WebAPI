using System;
using Microsoft.Extensions.Logging;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Services;

public class QuestionService : BaseService<Question>, IQuestionService
{
    public QuestionService(IUnitOfWork unitOfWork, ILogger<QuestionService> logger) : base(unitOfWork, logger)
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

    public async Task<Question> RemoveAnswerFromQuestionAsync(Question question, Answer answer)
    {
        if (question == null || answer == null)
        {
            throw new ArgumentNullException(nameof(question) + ", " + nameof(answer));
        }
        if (GetById(question.Id) == null || _unitOfWork.AnswerRepository.GetById(answer.Id)==null)
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
}

public interface IQuestionService : IBaseService<Question>
{
}