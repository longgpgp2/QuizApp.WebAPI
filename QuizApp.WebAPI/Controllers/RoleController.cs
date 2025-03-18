using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services.AuthService;
using QuizApp.Business.ViewModels.RoleViews;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to Roles page.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok((await _roleService.GetAllAsync()).Select(r => _mapper.Map<RoleViewModel>(r)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(_mapper.Map<RoleViewModel>(await _roleService.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoleCreateViewModel roleCreateViewModel)
    {
        return Ok(await _roleService.AddAsync(roleCreateViewModel));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Role role)
    {
        return Ok(await _roleService.UpdateAsync(role));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(Guid id, RoleEditViewModel roleEditViewModel)
    {
        return Ok(await _roleService.UpdateAsync(id, roleEditViewModel));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _roleService.DeleteAsync(id));
    }
}
