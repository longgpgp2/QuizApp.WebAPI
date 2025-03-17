using System;

namespace QuizApp.WebAPI.Configurations;

using AutoMapper;
using QuizApp.Business.ViewModels.AnswerViews;
using QuizApp.Business.ViewModels.Common;
using QuizApp.Business.ViewModels.QuestionViews;
using QuizApp.Business.ViewModels.QuizViews;
using QuizApp.WebAPI.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Question, BaseCommonViewModel<Question>>();

        CreateMap<Question, QuestionViewModel>();
        CreateMap<QuestionViewModel, Question>();
        CreateMap<QuestionCreateViewModel, Question>();

        CreateMap<AnswerCreateViewModel, Answer>();
        CreateMap<AnswerEditViewModel, Answer>();

        CreateMap<Quiz, QuizViewModel>();
        CreateMap<QuizViewModel, Quiz>();
        CreateMap<QuizCreateViewModel, Quiz>();

    }
}
