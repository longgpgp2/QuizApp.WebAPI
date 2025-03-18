using System;

namespace QuizApp.Business.ViewModels.RoleViews;

public class RoleCreateViewModel
{
    public required string Name { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
}
