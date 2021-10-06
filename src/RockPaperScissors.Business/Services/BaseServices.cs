using FluentValidation;
using RockPaperScissors.Business.Models;

namespace RockPaperScissors.Business.Services
{
    public abstract class BaseServices
    {
       protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            return false;
        }
    }
}
