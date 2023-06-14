using FluentValidation;

namespace ProjectFatec.WebApi.Models.Request.Validators
{
    public class AddressRequestValidator : AbstractValidator<AddressRequest>
    {
        public AddressRequestValidator() 
        {
            RuleFor(x => x.CEP).Length(8);
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.Neighborhood).NotEmpty();
            RuleFor(x => x.Number).NotEmpty().MinimumLength(1);
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.Street).NotEmpty();
        }
    }
}
