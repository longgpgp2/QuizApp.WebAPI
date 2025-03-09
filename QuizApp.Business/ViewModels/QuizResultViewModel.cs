namespace QuizApp.Business.ViewModels;

public class QuizResultViewModel
{
    public Guid QuizId { get; set; }

    public Guid UserId { get; set; }

    public ICollection<AnswerForTestViewModel> CorrectAnswers { get; set; } = [];

    public ICollection<QuestionForTestViewModel> TotalQuestions { get; set; } = [];

    public int Score { get; set; }

}
