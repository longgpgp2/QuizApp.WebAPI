using System;

namespace QuizApp.Business.ViewModels.UserViews;

public class UserEditViewModel
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? IsActive { get; set; }
}
