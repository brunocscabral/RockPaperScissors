using FluentValidation;

namespace RockPaperScissors.Business.Models.Validations
{
    class MoveValidation : AbstractValidator<Move>
    {
        public MoveValidation()
        {
            RuleFor(m => m.Name).NotEmpty().Length(2, 100);
        }
    }
}
