using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.QuizViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;

namespace QuizApp.WebAPI.Services;

public interface IQuizService : IBaseService<Quiz>
{
    Task<int> AddAsync(QuizCreateViewModel quizCreateViewModel);

    Task<bool> UpdateAsync(Guid id, QuizEditViewModel quizEditViewModel);

    Task<QuizPrepareInfoViewModel?> PrepareQuizForUserAsync(PrepareQuizViewModel prepareQuizViewModel);

    Task<QuizForTestViewModel> TakeQuizAsync(TakeQuizViewModel model);

    Task<bool> SubmitQuizAsync(QuizSubmissionViewModel model);

    Task<QuizResultViewModel> GetQuizResultAsync(GetQuizResultViewModel model);

    Task<bool> AddQuestionToQuiz(QuizQuestionCreateViewModel model);

    Task<bool> DeleteQuestionFromQuizAsync(Guid quizId, Guid questionId);

}
