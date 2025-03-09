using System;
using QuizApp.WebAPI.Models;

namespace QuizApp.Business.ViewModels;

public class QuizForTestViewModel
{
    public Guid Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public required string QuizCode { get; set; }

    public DateTime StartTime { get; set; }

    public int Duration { get; set; }

    public List<QuestionForTestViewModel> Questions { get; set; } = [];
}
