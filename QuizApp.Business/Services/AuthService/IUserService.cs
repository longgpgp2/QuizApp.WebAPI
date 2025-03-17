using Microsoft.AspNetCore.Identity;
using QuizApp.Business.ViewModels;
using QuizApp.Business.ViewModels.UserViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;

namespace QuizApp.Business.Services;

public interface IUserService: IBaseService<User>
{
    Task<IdentityResult> AddToRoleAsync(User user, string role);
    Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);
    Task<IdentityResult> CreateUserAsync(UserCreateViewModel userCreateViewModel);
    Task<User> FindByEmailAsync(string email);
    Task<User> FindByIdAsync(string userId);
    Task<User> FindByNameAsync(string userName);
    Task<string> GeneratePasswordResetTokenAsync(User user);
    Task<IList<string>> GetRolesAsync(User user);
    Task<bool> IsInRoleAsync(User user, string role);
    Task<IdentityResult> RemoveFromRoleAsync(User user, string role);
    Task<IdentityResult> ResetPasswordAsync(User user, string token, string newPassword);
    Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
    Task SignOutAsync();
    Task<User?> GetCurrentLoggedInUserAsync();
    UserViewModel GetUserViewModel(User user);
    Task<bool> UpdateAsync(Guid id, UserEditViewModel userEditViewModel);
}
