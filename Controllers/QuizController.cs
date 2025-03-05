using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuizController : ControllerBase
{
    private readonly QuizAppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public QuizController(QuizAppDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok(new string("Returned string...."));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quiz>>> GetAll()
    {
        return Ok(await _unitOfWork.QuizRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Quiz>> GetById(Guid id)
    {
        return Ok(await _unitOfWork.QuizRepository.GetByIdAsync(id));
    }

}
