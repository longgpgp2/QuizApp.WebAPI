using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    
    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to Answers page.");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Answer>>> GetAll()
    {
        return Ok(await _answerService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Answer>> GetById(Guid id)
    {
        return Ok(await _answerService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Answer>> Create(Answer answer)
    {
        return Ok(await _answerService.AddAsync(answer));
    }

    [HttpPut]
    public async Task<ActionResult<Answer>> Update(Answer answer)
    {
        return Ok(await _answerService.UpdateAsync(answer));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        return Ok(await _answerService.DeleteAsync(id));
    }
}
