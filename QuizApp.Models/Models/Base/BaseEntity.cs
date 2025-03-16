using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Models;

public class BaseEntity : IBaseEntity
{
    [Required]
    public required Guid Id { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;
}

public interface IBaseEntity
{
    [Required]
    public Guid Id { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}