using System;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Models;

public class Question : BaseEntity
{
    [Required]
    [StringLength(255, MinimumLength = 5)]
    public required string Content { get; set; }

    [Required]
    public required bool IsCorrect { get; set; } = false;
}
