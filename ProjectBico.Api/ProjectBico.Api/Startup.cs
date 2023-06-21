using Bico.WebApi.Authorization;
using Fatec.Domain.Services.Interfaces.User;
using Fatec.Domain.Services.User;
using Fatec.Domain.ValueTypes.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ProjectFatec.WebApi.Extensions;
using ProjectFatec.WebApi.IoC;
using ProjectFatec.WebApi.Jobs;
using System.Collections.Generic;
using System.IO;

namespace ProjectFatec.Api
{
    public class Startup
    {
        private readonly IAppSettings _appSettings;

        public Startup()
        {
            _appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build()
                .Get<AppSettings>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<MigrateDatabase>();

            services.AddControllersWithViews();
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            }); ;

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.GetDependencies(_appSettings);
            services.AddFluentValidation();
            services.AddFilters();
            services.AddSwaggerGen();

            // configure DI for application services
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAppSettings, AppSettings>();
            services.AddScoped<IUserService, UserService>();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                // my API name as defined in Config.cs - new ApiResource... or in DB ApiResources table
                o.Audience = _appSettings.Name;
                // URL of Auth server(API and Auth are separate projects/applications),
                // so for local testing this is http://localhost:5000 if you followed ID4 tutorials
                //o.Authority = Configuration["Settings:Authentication:Authority"];
                o.RequireHttpsMetadata = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    // Scopes supported by API as defined in Config.cs - new ApiResource... or in DB ApiScopes table
                    ValidAudiences = new List<string>() {
                        "api.read",
                        "api.write"
                    },
                    ValidateIssuer = true
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "MyTestService/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/MyTestService/swagger/v1/swagger.json", "TestService");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
