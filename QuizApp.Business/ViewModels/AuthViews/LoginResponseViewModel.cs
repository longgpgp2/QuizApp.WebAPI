using System;

namespace QuizApp.Business.ViewModels.AuthViews;

public class LoginResponseViewModel
{
    public required string Token { get; set; }

    public DateTime Expires { get; set; }

    public required string UserInformation { get; set; }
}
