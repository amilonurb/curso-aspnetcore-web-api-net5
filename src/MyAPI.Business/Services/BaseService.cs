using FluentValidation;
using MyAPI.Business.Models;

namespace MyAPI.Business.Services
{
    public abstract class BaseService
    {
        protected static bool IsValid<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            return validacao.Validate(entidade).IsValid;
        }
    }
}