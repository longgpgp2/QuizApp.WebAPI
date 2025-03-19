using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services.AuthService;
using QuizApp.Business.ViewModels.RoleViews;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/roles")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> GetAll()
    {
        return Ok((await _roleService.GetAllAsync()).Select(r => _mapper.Map<RoleViewModel>(r)));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(_mapper.Map<RoleViewModel>(await _roleService.GetByIdAsync(id)));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(RoleCreateViewModel roleCreateViewModel)
    {
        return Ok(await _roleService.AddAsync(roleCreateViewModel));
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> UpdateRole(Guid id, RoleEditViewModel roleEditViewModel)
    {
        return Ok(await _roleService.UpdateAsync(id, roleEditViewModel));
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _roleService.DeleteAsync(id));
    }
}
