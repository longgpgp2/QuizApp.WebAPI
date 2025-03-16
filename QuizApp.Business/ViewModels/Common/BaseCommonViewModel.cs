using System;
using QuizApp.WebAPI.Models;

namespace QuizApp.Business.ViewModels.Common;

public class BaseCommonViewModel<T> : IBaseCommonViewModel<T> where T : IBaseEntity
{

}

public interface IBaseCommonViewModel<T> where T : IBaseEntity
{
}