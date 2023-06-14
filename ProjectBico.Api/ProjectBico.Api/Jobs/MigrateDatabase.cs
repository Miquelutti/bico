using Fatec.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectFatec.WebApi.Jobs
{
    public class MigrateDatabase : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrateDatabase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetService<BicoContext>()
                    .Database.Migrate();
            }

            return Task.CompletedTask;
        }
    }
}
