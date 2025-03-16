using QuizApp.Business.ViewModels.AnswerViews;
using QuizApp.Business.ViewModels.Common;
using QuizApp.Business.ViewModels.QuestionViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;

namespace QuizApp.WebAPI.Services;

public interface IQuestionService : IBaseService<Question>
{

    Task<int> AddAsync(QuestionCreateViewModel questionCreateViewModel);

    Task<bool> UpdateAsync(Guid id, QuestionEditViewModel questionEditViewModel);
    

}