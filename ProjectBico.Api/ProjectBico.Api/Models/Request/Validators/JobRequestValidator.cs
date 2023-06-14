using FluentValidation;

namespace ProjectFatec.WebApi.Models.Request.Validators
{
    public class JobRequestValidator : AbstractValidator<JobRequest>
    {
        public JobRequestValidator() 
        {
            RuleFor(x => x.ProviderId).NotEmpty();
            RuleFor(x => x.JobCategoryId).NotEmpty();
            RuleFor(x => x.PriceTime).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.EndTime).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
        }
    }
}