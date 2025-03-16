using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.ViewModels.Common;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly IMapper _mapper;

    public QuestionController(IQuestionService questionService, IMapper mapper)
    {
        _questionService = questionService;
        _mapper = mapper;
    }


    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to Questions page.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var questions = await _questionService.GetAllAsync();
        return Ok(questions.Select(q => _mapper.Map<QuestionViewModel>(q)));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _questionService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Question question)
    {
        return Ok(await _questionService.AddAsync(question));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Question question)
    {
        return Ok(await _questionService.UpdateAsync(question));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _questionService.DeleteAsync(id));
    }
}
