using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.UserViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.Business.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger, UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper) : base(unitOfWork, logger, mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> CreateUserAsync(UserCreateViewModel userCreateViewModel)
    {
        if (!userCreateViewModel.Password.Equals(userCreateViewModel.ConfirmPassword))
        {
            throw new InvalidOperationException("Password not matched!");
        }
        if (_unitOfWork.UserRepository.GetQuery().FirstOrDefault(u => u.Email == userCreateViewModel.Email) != null)
        {
            throw new InvalidOperationException("Email already taken");
        }
        _logger.LogInformation("Registering User");

        return await _userManager.CreateAsync(_mapper.Map<User>(userCreateViewModel), userCreateViewModel.Password);
    }

    public async Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
    {
        return await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<User> FindByIdAsync(string userId)
    {
        return await _userManager.FindByIdAsync(userId);
    }

    public async Task<User> FindByNameAsync(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
    {
        if (!changePasswordViewModel.NewPassword.Equals(changePasswordViewModel.ConfirmPassword))
            throw new InvalidOperationException("Password not match!");
        var user = await FindByIdAsync(changePasswordViewModel.Id.ToString())
            ?? throw new ResourceNotFoundException("User not found to change password");
        return await _userManager.ChangePasswordAsync(user, changePasswordViewModel.Password, changePasswordViewModel.NewPassword);
    }

    public async Task<string> GeneratePasswordResetTokenAsync(User user)
    {
        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword)
    {
        return await _userManager.ResetPasswordAsync(user, token, newPassword);
    }

    public async Task<IList<string>> GetRolesAsync(User user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<IdentityResult> AddToRoleAsync(User user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<IdentityResult> RemoveFromRoleAsync(User user, string role)
    {
        return await _userManager.RemoveFromRoleAsync(user, role);
    }

    public async Task<bool> IsInRoleAsync(User user, string role)
    {
        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<User?> GetCurrentLoggedInUserAsync()
    {
        return await _userManager.GetUserAsync(_signInManager.Context.User);
    }

    public UserViewModel GetUserViewModel(User user)
    {
        return _mapper.Map<UserViewModel>(user);
    }

    public async Task<bool> UpdateAsync(Guid id, UserEditViewModel userEditViewModel)
    {
        var user = await FindByIdAsync(id.ToString()) ?? throw new ResourceNotFoundException("User not found to update!");
        user.FirstName = userEditViewModel.FirstName ?? user.FirstName;
        user.LastName = userEditViewModel.LastName ?? user.LastName;
        user.PhoneNumber = userEditViewModel.PhoneNumber ?? user.PhoneNumber;
        user.DateOfBirth = userEditViewModel.DateOfBirth ?? user.DateOfBirth;
        user.IsActive = userEditViewModel.IsActive ?? user.IsActive;
        return await UpdateAsync(user);
    }
}
