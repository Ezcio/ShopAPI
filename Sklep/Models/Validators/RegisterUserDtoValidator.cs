using FluentValidation;
using Sklep.Entities;
using System.Linq;

namespace Sklep.Models.Validators
{
    public class RegisterUserDtoValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(Shop shopContext)
        {
            RuleFor(x => x.Mail)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Mail)
                .Custom((value, context) =>
                {
                    var emailInUse = shopContext.User.Where(u => u.Mail == value).Any();
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

            RuleFor(x => x.Password).MinimumLength(8);

            RuleFor(x=> x.ConfirmPassword).Equal(e => e.Password);
        }
    }
}
