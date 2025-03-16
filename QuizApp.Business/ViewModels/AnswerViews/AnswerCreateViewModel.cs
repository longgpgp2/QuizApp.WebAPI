using System;

namespace QuizApp.Business.ViewModels.AnswerViews;

public class AnswerCreateViewModel
{
    public required string Content { get; set; }

    public bool IsCorrect { get; set; } = false;

    public bool IsActive { get; set; } = true;

}
