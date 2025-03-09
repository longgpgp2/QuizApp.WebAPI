# Add package for QuizApp.Models
dotnet add QuizApp.Models package Microsoft.EntityFrameworkCore
dotnet add QuizApp.Models package Microsoft.AspNetCore.Identity.EntityFrameworkCore

# Add package for QuizApp.Business
dotnet add QuizApp.Business package Microsoft.EntityFrameworkCore
dotnet add QuizApp.Business package MediatR
dotnet add QuizApp.Business package AutoMapper
dotnet add QuizApp.Business package Newtonsoft.Json

# Add package for QuizApp.Data
dotnet add QuizApp.Data package Microsoft.EntityFrameworkCore
dotnet add QuizApp.Data package Microsoft.EntityFrameworkCore.SqlServer
dotnet add QuizApp.Data package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add QuizApp.Data package Microsoft.AspNetCore.Identity

# Add package for QuizApp.API
dotnet add QuizApp.API package Microsoft.EntityFrameworkCore
dotnet add QuizApp.API package Microsoft.EntityFrameworkCore.SqlServer
dotnet add QuizApp.API package Microsoft.EntityFrameworkCore.Design
dotnet add QuizApp.API package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add QuizApp.API package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add QuizApp.API package Microsoft.AspNetCore.Identity.UI
dotnet add QuizApp.API package Microsoft.AspNetCore.API.NewtonsoftJson
dotnet add QuizApp.API package Microsoft.AspNetCore.API.Versioning
dotnet add QuizApp.API package Microsoft.AspNetCore.API.Versioning.ApiExplorer
dotnet add QuizApp.API package Swashbuckle.AspNetCore
dotnet add QuizApp.API package Swashbuckle.AspNetCore.Swagger
dotnet add QuizApp.API package Swashbuckle.AspNetCore.SwaggerGen
dotnet add QuizApp.API package Swashbuckle.AspNetCore.SwaggerUI
dotnet add QuizApp.API package Microsoft.Extensions.Configuration
