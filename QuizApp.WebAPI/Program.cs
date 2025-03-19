using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuizApp.Business.Services;
using QuizApp.Business.Services.AuthService;
using QuizApp.WebAPI.Configurations;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Middleware;
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

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IAuthService, AuthService>();

// Register JWT with Bearer token
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration["JWT:Secret"] ?? "supersecuredsecretkey"))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", opt => opt
        .WithOrigins(builder.Configuration.GetSection("CORs:AllowedOrigins").Get<string[]>() ?? [])
        .WithHeaders(builder.Configuration.GetSection("CORs:AllowedHeaders").Get<string[]>() ?? [])
        .WithMethods(builder.Configuration.GetSection("CORs:AllowedMethods").Get<string[]>() ?? []));

    options.AddPolicy("AllowAnyOrigin", opt => opt
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});


builder.Services.AddLogging();

builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Services.AddAutoMapper(typeof(MappingProfile));
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
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseCustomExceptionHandler();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.Run();