using System;

namespace QuizApp.WebAPI.Models;

public class UserQuiz
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid QuizId { get; set; }

    public required string QuizCode { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime FinishedAt { get; set; }

    public ICollection<UserAnswer> UserAnswers { get; set; } = [];

}
