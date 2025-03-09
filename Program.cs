using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using QuizApp.Business.Services;
using QuizApp.Business.Services.AuthService;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;
using QuizApp.WebAPI.Repositories;
using QuizApp.WebAPI.Services;
using QuizApp.WebAPI.Services.BaseServices;
using QuizApp.WebAPI.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// config sqlserver connection
builder.Services.AddDbContext<QuizAppDbContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddScoped<IQuizService, QuizService>();

builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<IAnswerService, AnswerService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddLogging();

builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<QuizAppDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.Run();