using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }


    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to Questions page.");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetAll()
    {
        return Ok(await _questionService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> GetById(Guid id)
    {
        return Ok(await _questionService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Question>> Create(Question question)
    {
        return Ok(await _questionService.AddAsync(question));
    }

    [HttpPut]
    public async Task<ActionResult<Question>> Update(Question question)
    {
        return Ok(await _questionService.UpdateAsync(question));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        return Ok(await _questionService.DeleteAsync(id));
    }
}
