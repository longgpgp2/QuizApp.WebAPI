using System;

namespace QuizApp.WebAPI.Models;

public class UserAnswer
{
    public Guid Id { get; set; }

    public Guid UserQuizId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid AnswerId { get; set; }

    public bool IsCorrect { get; set; }
}
