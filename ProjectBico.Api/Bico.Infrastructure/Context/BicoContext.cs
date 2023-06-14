using Fatec.Domain.Entities;
using Fatec.Domain.Services.Interfaces.Clock;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fatec.Infrastructure.Extensions;
using Fatec.Infrastructure.ModelConfig.JobCategory;
using Fatec.Infrastructure.ModelConfig.Address;
using Fatec.Infrastructure.ModelConfig.Contract;
using Fatec.Infrastructure.ModelConfig.ContractStatus;
using Fatec.Infrastructure.ModelConfig.Job;
using Fatec.Infrastructure.ModelConfig.Request;
using Fatec.Infrastructure.ModelConfig.RequestStatus;
using Fatec.Infrastructure.ModelConfig.User;

namespace Fatec.Infrastructure.Context
{
    public class BicoContext : DbContext
    {
        private readonly IClock _clock;

        public BicoContext(DbContextOptions options,
            IClock clock) : base(options)
        {
            _clock = clock;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new JobCategoryConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new ContractConfig());
            modelBuilder.ApplyConfiguration(new ContractStatusConfig());
            modelBuilder.ApplyConfiguration(new JobConfig());
            modelBuilder.ApplyConfiguration(new RequestConfig());
            modelBuilder.ApplyConfiguration(new RequestStatusConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.AddSeeds();
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var addedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            addedEntities.ForEach(entityEntry =>
            {
                if (!(entityEntry.Entity is Entity entity))
                    return;

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedOn = _clock.UtcDateTimeNow();
                }

                if (entityEntry.State != EntityState.Modified) return;

                entity.UpdatedOn = _clock.UtcDateTimeNow();
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
