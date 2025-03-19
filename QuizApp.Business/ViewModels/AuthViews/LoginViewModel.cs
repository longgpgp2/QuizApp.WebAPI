using System;

namespace QuizApp.Business.ViewModels.AuthViews;

public class LoginViewModel
{
    public required string UserName { get; set; }

    public required string Password { get; set; }
}
