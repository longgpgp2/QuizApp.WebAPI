using QuizApp.Business.ViewModels;

namespace QuizApp.WebAPI.Services;

public class QuizPrepareInfoViewModel
{

    public Guid Id { get; set; }

    public required string Title { get; set; }

    public string? Description { get; set; }

    public required int Duration { get; set; }

    public string? ThumbnailUrl { get; set; }

    public required string QuizCode { get; set; }

    public required UserViewModel User { get; set; }
}