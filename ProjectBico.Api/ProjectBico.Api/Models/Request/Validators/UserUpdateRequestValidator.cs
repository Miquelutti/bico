using Fatec.Domain.Validations.Common;
using FluentValidation;

namespace ProjectFatec.WebApi.Models.Request.Validators
{
    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator() 
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.CPF).Length(11).CPF();
        }
    }
}
