using System;

namespace QuizApp.Business.ViewModels.QuizViews;

public class QuizCreateViewModel
{
    public required string Title { get; set; }

    public string? Description { get; set; }

    public int Duration { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<QuestionIdWithOrderViewModel> QuestionIdWithOrders { get; set; } = [];

}
