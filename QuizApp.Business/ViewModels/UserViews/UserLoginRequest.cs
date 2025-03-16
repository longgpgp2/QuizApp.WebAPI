using System;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Business.ViewModels.UserViews;

public class UserLoginRequest
{
    [Required(ErrorMessage = "{0} is required")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public required string Password { get; set; }
}
