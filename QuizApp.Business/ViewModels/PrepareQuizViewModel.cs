using System;

namespace QuizApp.Business.ViewModels;

public class PrepareQuizViewModel
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public required string QuizCode { get; set; }
}
