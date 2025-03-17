using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.ViewModels.AnswerViews;
using QuizApp.Business.ViewModels.Common;
using QuizApp.Business.ViewModels.QuestionViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]s")]
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
        return Ok((await _questionService.GetAllAsync()).Select(q => _mapper.Map<QuestionViewModel>(q)));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(_mapper.Map<QuestionViewModel>(await _questionService.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestionWithAnswer([FromBody] QuestionCreateViewModel questionCreateViewModel)
    {

        return Ok(await _questionService.AddAsync(questionCreateViewModel));
    }


    [HttpPut]
    public async Task<IActionResult> Update(Question question)
    {
        return Ok(await _questionService.UpdateAsync(question));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestionWithAnswer([FromRoute] Guid id, [FromBody] QuestionEditViewModel questionEditViewModel)
    {
        return Ok(await _questionService.UpdateAsync(id, questionEditViewModel));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _questionService.DeleteAsync(id));
    }
}
