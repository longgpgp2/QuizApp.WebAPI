using System;

namespace QuizApp.Business.ViewModels.QuizViews;

public class QuizEditViewModel
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public bool? IsActive { get; set; }

    public ICollection<QuestionIdWithOrderViewModel> QuestionIdWithOrders { get; set; } = [];
}
