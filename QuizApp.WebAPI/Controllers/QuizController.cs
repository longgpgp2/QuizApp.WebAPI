using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to quizzes page.");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quiz>>> GetAll()
    {
        return Ok(await _quizService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Quiz>> GetById(Guid id)
    {
        return Ok(await _quizService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Quiz>> Create(Quiz quiz)
    {
        return Ok(await _quizService.AddAsync(quiz));
    }

    [HttpPut]
    public async Task<ActionResult<Quiz>> Update(Quiz quiz)
    {
        return Ok(await _quizService.UpdateAsync(quiz));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        return Ok(await _quizService.DeleteAsync(id));
    }
}
