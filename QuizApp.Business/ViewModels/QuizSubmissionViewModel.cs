namespace QuizApp.Business.ViewModels;

public class QuizSubmissionViewModel
{
    public Guid QuizId { get; set; }

    public Guid UserId { get; set; }

    public List<UserAnswerSubmissionViewModel> UserAnswers { get; set; } = [];

    // just in case

    public DateTime StartTime { get; set; }
}
