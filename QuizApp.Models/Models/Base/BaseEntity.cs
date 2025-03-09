using System.ComponentModel.DataAnnotations;

namespace QuizApp.WebAPI.Models;

public class BaseEntity : IBaseEntity
{
    [Required]
    public required Guid Id { get; set; }

    public bool IsDeleted { get; set; }
}

public interface IBaseEntity
{
    [Required]
    public Guid Id { get; set; }

    public bool IsDeleted { get; set; }
}