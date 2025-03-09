using System;
using Microsoft.Extensions.Logging;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Services;

public class AnswerService : BaseService<Answer>, IAnswerService
{
    public AnswerService(IUnitOfWork unitOfWork, ILogger<AnswerService> logger) : base(unitOfWork, logger)
    {
    }
}

public interface IAnswerService: IBaseService<Answer>
{
}