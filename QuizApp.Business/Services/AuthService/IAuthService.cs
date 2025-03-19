using System;
using QuizApp.Business.ViewModels.AuthViews;

namespace QuizApp.Business.Services.AuthService;

public interface IAuthService
{
    Task<LoginResponseViewModel> LoginAsync(LoginViewModel loginViewModel);

    Task<LoginResponseViewModel> RegisterAsync(RegisterViewModel registerViewModel);
}
