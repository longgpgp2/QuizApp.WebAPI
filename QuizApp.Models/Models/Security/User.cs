using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuizApp.WebAPI.Models;

public class User : IdentityUser<Guid>, IBaseEntity
{
    [StringLength(50, MinimumLength = 3)]
    public required string FirstName { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public required string LastName { get; set; }

    public required string DisplayName { get; set; }

    private DateTime _dateOfBirth;
    [Required]
    public required DateTime DateOfBirth
    {
        get { return _dateOfBirth; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future");
            }
            _dateOfBirth = value;
        }
    }

    [StringLength(500)]
    public string? Avatar { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    public ICollection<Role> Roles { get; set; } = [];

    public ICollection<UserQuiz> UserQuizzes { get; set; } = [];
    public bool IsDeleted { get; set; } = false;

}
