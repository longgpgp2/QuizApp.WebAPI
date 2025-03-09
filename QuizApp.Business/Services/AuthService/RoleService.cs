using System;
using Microsoft.Extensions.Logging;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.Business.Services.AuthService;

public class RoleService : BaseService<Role>, IRoleService
{
    public RoleService(IUnitOfWork unitOfWork, ILogger<RoleService> logger) : base(unitOfWork, logger)
    {
    }
}

public interface IRoleService: IBaseService<Role>
{
}