using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuizApp.WebAPI.Models;

public class Role : IdentityRole<Guid>, IBaseEntity
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public required string Description { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;
    
    public bool IsDeleted { get; set; } = false;

}
