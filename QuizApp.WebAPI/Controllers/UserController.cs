using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to Users page.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(await _userService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        return Ok(await _userService.AddAsync(user));
    }

    [HttpPut]
    public async Task<IActionResult> Update(User user)
    {
        return Ok(await _userService.UpdateAsync(user));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _userService.DeleteAsync(id));
    }
}
