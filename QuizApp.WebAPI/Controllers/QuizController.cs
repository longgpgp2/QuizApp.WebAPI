using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.Common;
using QuizApp.Business.ViewModels.QuizViews;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]zes")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;
    private readonly IMapper _mapper;

    public QuizController(IQuizService quizService, IMapper mapper)
    {
        _quizService = quizService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to quizzes page.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok((await _quizService.GetAllAsync()).Select(q => _mapper.Map<QuizViewModel>(q)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(_mapper.Map<QuizViewModel>(await _quizService.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuizWithQuestions(QuizCreateViewModel quizCreateViewModel)
    {
        return Ok(await _quizService.AddAsync(quizCreateViewModel));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Quiz quiz)
    {
        return Ok(await _quizService.UpdateAsync(quiz));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuizWithQuestions([FromRoute] Guid id, [FromBody] QuizEditViewModel questionEditViewModel)
    {
        return Ok(await _quizService.UpdateAsync(id, questionEditViewModel));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _quizService.DeleteAsync(id));
    }

    [HttpDelete("{id}/questions/{questionId}")]
    public async Task<IActionResult> DeleteQuestionFromQuiz([FromRoute] Guid id, [FromRoute] Guid questionId)
    {
        return Ok(await _quizService.DeleteQuestionFromQuizAsync(id, questionId));
    }

    [HttpPost("PrepareQuizForUser")]
    public async Task<IActionResult> AddQuestionToQuiz(PrepareQuizViewModel prepareQuizViewModel)
    {
        return Ok(await _quizService.PrepareQuizForUserAsync(prepareQuizViewModel));
    }

    [HttpPost("takeQuiz")]
    public async Task<IActionResult> TakeQuiz(TakeQuizViewModel takeQuizViewModel)
    {
        return Ok(await _quizService.TakeQuizAsync(takeQuizViewModel));
    }

    [HttpPost("submitQuiz")]
    public async Task<IActionResult> SubmitQuiz(QuizSubmissionViewModel quizSubmissionViewModel)
    {
        return Ok(await _quizService.SubmitQuizAsync(quizSubmissionViewModel));
    }
}
