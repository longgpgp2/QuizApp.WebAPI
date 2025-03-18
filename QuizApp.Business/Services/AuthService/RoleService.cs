using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.Business.ViewModels.RoleViews;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.Business.Services.AuthService;

public class RoleService : BaseService<Role>, IRoleService
{
    public RoleService(IUnitOfWork unitOfWork, ILogger<RoleService> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
    {
    }

    public async Task<bool> AddAsync(RoleCreateViewModel model)
    {
        var role = _mapper.Map<Role>(model);
        return await AddAsync(role) > 0;
    }

    public async Task<bool> UpdateAsync(Guid id, RoleEditViewModel model)
    {

        var role = await GetByIdAsync(id)
            ?? throw new ResourceNotFoundException("Role not found to update");

        role.Name = model.Name ?? role.Name;
        role.Description = model.Description ?? role.Description;
        role.IsActive = model.IsActive ?? role.IsActive;

        return await UpdateAsync(role);
    }
}
