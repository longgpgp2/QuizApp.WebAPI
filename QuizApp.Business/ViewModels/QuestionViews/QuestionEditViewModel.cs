using System;
using QuizApp.Business.ViewModels.AnswerViews;
using QuizApp.WebAPI.Models;

namespace QuizApp.Business.ViewModels.QuestionViews;

public class QuestionEditViewModel
{
    public Guid Id { get; set; }

    public string? Content { get; set; }

    public QuestionTypeEnum? QuestionType { get; set; }

    public bool? IsActive { get; set; }

    public ICollection<AnswerEditViewModel> Answer { get; set; } = [];
}
