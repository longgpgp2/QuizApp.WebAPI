using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/quizzes")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(_mapper.Map<QuizViewModel>(await _quizService.GetByIdAsync(id)));
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> CreateQuizWithQuestions(QuizCreateViewModel quizCreateViewModel)
    {
        return Ok(await _quizService.AddAsync(quizCreateViewModel));
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> UpdateQuizWithQuestions([FromRoute] Guid id, [FromBody] QuizEditViewModel questionEditViewModel)
    {
        return Ok(await _quizService.UpdateAsync(id, questionEditViewModel));
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _quizService.DeleteAsync(id));
    }

    [HttpDelete]
    [Route("{id}/questions/{questionId}")]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> DeleteQuestionFromQuiz([FromRoute] Guid id, [FromRoute] Guid questionId)
    {
        return Ok(await _quizService.DeleteQuestionFromQuizAsync(id, questionId));
    }

    [HttpPost]
    [Route("PrepareQuizForUser")]
    public async Task<IActionResult> AddQuestionToQuiz(PrepareQuizViewModel prepareQuizViewModel)
    {
        return Ok(await _quizService.PrepareQuizForUserAsync(prepareQuizViewModel));
    }

    [HttpPost]
    [Route("takeQuiz")]
    public async Task<IActionResult> TakeQuiz(TakeQuizViewModel takeQuizViewModel)
    {
        return Ok(await _quizService.TakeQuizAsync(takeQuizViewModel));
    }

    [HttpPost]
    [Route("submitQuiz")]
    public async Task<IActionResult> SubmitQuiz(QuizSubmissionViewModel quizSubmissionViewModel)
    {
        return Ok(await _quizService.SubmitQuizAsync(quizSubmissionViewModel));
    }
}
