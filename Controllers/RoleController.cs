using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services.AuthService;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to Roles page.");
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> GetAll()
    {
        return Ok(await _roleService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Role>> GetById(Guid id)
    {
        return Ok(await _roleService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Role>> Create(Role role)
    {
        return Ok(await _roleService.AddAsync(role));
    }

    [HttpPut]
    public async Task<ActionResult<Role>> Update(Role role)
    {
        return Ok(await _roleService.UpdateAsync(role));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id)
    {
        return Ok(await _roleService.DeleteAsync(id));
    }
}
