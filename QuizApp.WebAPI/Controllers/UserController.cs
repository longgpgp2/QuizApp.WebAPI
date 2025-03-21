using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.UserViews;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    [HttpGet]
    [Route("index")]
    public IActionResult Index()
    {
        return Ok("Welcome to Users page.");
    }

    [HttpGet]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> GetAll()
    {
        return Ok((await _userService.GetAllAsync()).Select(u => _mapper.Map<UserViewModel>(u)));
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(_mapper.Map<User>(await _userService.GetByIdAsync(id)));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(UserCreateViewModel userCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(await _userService.CreateUserAsync(userCreateViewModel));
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(Roles = "Admin,Editor")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserEditViewModel userEditViewModel)
    {
        return Ok(await _userService.UpdateAsync(id, userEditViewModel));
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _userService.DeleteAsync(id));
    }

    [HttpPost]
    [Route("changePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(await _userService.ChangePasswordAsync(changePasswordViewModel));
    }
}
