using System;

namespace QuizApp.Business.ViewModels.RoleViews;

public class RoleEditViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }
}
