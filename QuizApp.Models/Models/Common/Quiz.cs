using System;
using System.ComponentModel.DataAnnotations;
using QuizApp.Data.Models;

namespace QuizApp.WebAPI.Models;

public class Quiz : BaseEntity
{
    [Required]
    [StringLength(255, MinimumLength = 5)]
    public required string Title { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Required]
    [Range(0, 3600)]
    public int Duration { get; set; }

    [StringLength(500)]
    public string? ThumbnailUrl { get; set; }

    public ICollection<UserQuiz> UserQuizzes { get; set; } = [];

    public ICollection<QuizQuestion> QuizQuestions { get; set; } = [];


}
