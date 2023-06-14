using FluentValidation;

namespace ProjectFatec.WebApi.Models.Request.Validators
{
    public class RequestRequestValidator : AbstractValidator<RequestRequest>
    {
        public RequestRequestValidator() 
        {
            RuleFor(x => x.ContractingUserId).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ProviderId).NotEmpty();
            RuleFor(x => x.JobId).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();
        }
    }
}