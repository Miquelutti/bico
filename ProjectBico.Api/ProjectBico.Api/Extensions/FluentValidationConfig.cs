using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectFatec.Api;

namespace ProjectFatec.WebApi.Extensions
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddMvc()
                    .AddFluentValidation(options =>
                    {
                        options.RegisterValidatorsFromAssemblyContaining(typeof(Startup));
                    });
        }
    }
}
