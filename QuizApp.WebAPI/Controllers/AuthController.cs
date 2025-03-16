using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Business.Services;
using QuizApp.Business.ViewModels.UserViews;

namespace QuizApp.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userService.SignInAsync(request.UserName, request.Password, false, false);

        return Ok(result);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _userService.SignOutAsync();

        return Ok();
    }
}
