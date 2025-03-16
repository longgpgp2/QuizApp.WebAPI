using System;
using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

namespace QuizApp.Business.Services.AuthService;

public class RoleService : BaseService<Role>, IRoleService
{
    public RoleService(IUnitOfWork unitOfWork, ILogger<RoleService> logger, IMapper mapper) : base(unitOfWork, logger, mapper)
    {
    }
}
