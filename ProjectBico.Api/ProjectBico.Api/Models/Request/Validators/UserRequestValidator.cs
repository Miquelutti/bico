using Fatec.Domain.Validations.Common;
using FluentValidation;

namespace ProjectFatec.WebApi.Models.Request.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.CPF).Length(11).CPF();
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Address).NotNull();
        }
    }
}
