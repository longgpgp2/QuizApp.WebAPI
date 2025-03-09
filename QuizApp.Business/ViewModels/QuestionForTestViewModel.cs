namespace QuizApp.Business.ViewModels;

public class QuestionForTestViewModel
{
    public Guid Id { get; set; }

    public required string Content { get; set; }

    public required string QuestionType { get; set; }

    public List<AnswerForTestViewModel> Answers { get; set; } = [];
}
