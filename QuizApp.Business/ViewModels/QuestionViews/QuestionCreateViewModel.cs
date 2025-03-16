using System;
using QuizApp.Business.ViewModels.AnswerViews;
using QuizApp.WebAPI.Models;

namespace QuizApp.Business.ViewModels.QuestionViews;

public class QuestionCreateViewModel
{
    public required string Content { get; set; }

    public QuestionTypeEnum QuestionType { get; set; } = QuestionTypeEnum.MultipleChoice;

    public bool IsActive { get; set; } = true;

    public ICollection<AnswerCreateViewModel> Answer { get; set; }

}
