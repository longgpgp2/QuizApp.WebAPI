using System;

namespace QuizApp.WebAPI.Configurations;

using AutoMapper;
using QuizApp.Business.ViewModels.Common;
using QuizApp.WebAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Question, QuestionViewModel>();
        CreateMap<QuestionViewModel, Question>();
    }
}
