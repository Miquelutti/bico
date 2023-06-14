using Microsoft.Extensions.DependencyInjection;
using ProjectFatec.WebApi.Filters;

namespace ProjectFatec.WebApi.Extensions
{
    public static class FiltersConfig
    {
        public static void AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelStateFilter));
                options.Filters.Add(typeof(ExecutionExceptionFilter));
            });

            services.AddScoped<ModelStateFilter>();
            services.AddScoped<ExecutionExceptionFilter>();
        }
    }
}
