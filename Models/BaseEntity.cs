using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Models;

public class BaseEntity
{
    [Required]
    public required Guid Id { get; set; }

    public bool IsDeleted { get; set; }
}