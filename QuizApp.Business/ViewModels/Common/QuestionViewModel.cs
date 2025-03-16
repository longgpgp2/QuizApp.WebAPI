using System;

namespace QuizApp.Business.ViewModels.Common;

public class QuestionViewModel
{
    public Guid Id { get; set; }

    public required string Content { get; set; }

    public required string QuestionType { get; set; }

    public bool IsActive { get; set; }
}
