using System;
using QuizApp.WebAPI.Models;

namespace QuizApp.Business.ViewModels.Common;

public class QuestionViewModel: IBaseCommonViewModel<Question>
{
    public Guid Id { get; set; }

    public required string Content { get; set; }

    public required string QuestionType { get; set; }

    public bool IsActive { get; set; }
}
