using System;
using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.AuthViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;

namespace QuizApp.Business.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;


    public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService, IConfiguration configuration, IMapper mapper)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenService = tokenService;
        _configuration = configuration;
        _mapper = mapper;
    }

    public async Task<LoginResponseViewModel> LoginAsync(LoginViewModel loginViewModel)
    {
        var user = await _userManager.FindByNameAsync(loginViewModel.UserName)
            ?? throw new ResourceNotFoundException("Invalid Username or Password!");
        if (!user.IsActive)
        {
            throw new UnauthorizedAccessException("Your account is deactivated. Please contact an administrator.");
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);
        if (!result.Succeeded)
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }
        var userRoles = await _userManager.GetRolesAsync(user);

        var accessToken = await _tokenService.GenerateTokenAsync(user, userRoles);

        if (!int.TryParse(_configuration["JWT:AccessTokenExpiryMinutes"], out var expiryMinutes))
        {
            expiryMinutes = 15;
        }

        return new LoginResponseViewModel
        {
            Token = accessToken,
            Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
            UserInformation = JsonSerializer.Serialize(_mapper.Map<UserViewModel>(user))
        };
    }

    public async Task<LoginResponseViewModel> RegisterAsync(RegisterViewModel registerViewModel)
    {
        if (await _userManager.FindByNameAsync(registerViewModel.UserName) != null)
        {
            throw new ArgumentException("Username is already taken.");
        }
        if (await _userManager.FindByEmailAsync(registerViewModel.Email) != null)
        {
            throw new ArgumentException("Email is already registered.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            DisplayName = registerViewModel.FirstName + " " + registerViewModel.LastName,
            UserName = registerViewModel.UserName,
            Email = registerViewModel.Email,
            PhoneNumber = registerViewModel.PhoneNumber,
            DateOfBirth = registerViewModel.DateOfBirth,
            IsActive = true,
        };

        var result = await _userManager.CreateAsync(user, registerViewModel.Password);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException($"User registration failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }


        var userRoles = await _userManager.GetRolesAsync(user);
        var accessToken = await _tokenService.GenerateTokenAsync(user, userRoles);

        if (!int.TryParse(_configuration["JWT:AccessTokenExpiryMinutes"], out var expiryMinutes))
        {
            expiryMinutes = 15;
        }

        return new LoginResponseViewModel
        {
            Token = accessToken,
            Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
            UserInformation = JsonSerializer.Serialize(_mapper.Map<UserViewModel>(user))
        };
    }

}
