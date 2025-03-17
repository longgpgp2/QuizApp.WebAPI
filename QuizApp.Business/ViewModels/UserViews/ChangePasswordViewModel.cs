using System;

namespace QuizApp.Business.ViewModels.UserViews;

public class ChangePasswordViewModel
{
    public required Guid Id { get; set; }

    public required string UserName { get; set; }

    public required string Password { get; set; }

    public required string NewPassword { get; set; }

    public required string ConfirmPassword { get; set; }

}
