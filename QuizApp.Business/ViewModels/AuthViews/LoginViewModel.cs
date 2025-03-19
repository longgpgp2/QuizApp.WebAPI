using System.ComponentModel.DataAnnotations;

namespace QuizApp.Business.ViewModels.AuthViews;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username is required")]
    [RegularExpression(@"^(?:[a-zA-Z0-9_]+|[\w-]+@([\w-]+\.)+[\w-]{2,4})$", 
        ErrorMessage = "Invalid Username format")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters")]
    public string Password { get; set; } = string.Empty;
}
