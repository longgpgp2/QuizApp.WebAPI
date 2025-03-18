using QuizApp.Business.ViewModels.RoleViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;

namespace QuizApp.Business.Services.AuthService;

public interface IRoleService: IBaseService<Role>
{
    Task<bool> AddAsync(RoleCreateViewModel model);

    Task<bool> UpdateAsync(Guid id, RoleEditViewModel model);

}