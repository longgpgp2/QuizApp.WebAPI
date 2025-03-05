using System;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Models;

public class Question : BaseEntity
{
    [Required]
    [StringLength(5000, MinimumLength = 5)]
    public required string Content { get; set; }

    [Required]
    [EnumDataType(typeof(QuestionTypeEnum), ErrorMessage = "Invalid Question Type")]
    public required string QuestionType { get; set; }

    public ICollection<Quiz> Quizzes { get; set; } = [];

    public ICollection<Answer> Answers { get; set; } = [];
}


public enum QuestionTypeEnum
{
    MultipleChoice,
    SingleChoice,
    TrueFalse,
    FillInTheBlanks,
    ShortAnswer,
    LongAnswer
}