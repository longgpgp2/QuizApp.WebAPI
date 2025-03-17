using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.UserViews;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]s")]
[ApiController]
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
    public async Task<IActionResult> GetAll()
    {
        return Ok((await _userService.GetAllAsync()).Select(u => _mapper.Map<UserViewModel>(u)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok(_mapper.Map<User>(await _userService.GetByIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateViewModel userCreateViewModel)
    {
        return Ok(await _userService.CreateUserAsync(userCreateViewModel));
    }

    [HttpPut]
    public async Task<IActionResult> Update(User user)
    {
        return Ok(await _userService.UpdateAsync(user));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserEditViewModel userEditViewModel)
    {
        return Ok(await _userService.UpdateAsync(id, userEditViewModel));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _userService.DeleteAsync(id));
    }

    [HttpPost("changePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
    {
        return Ok(await _userService.ChangePasswordAsync(changePasswordViewModel));
    }
}
