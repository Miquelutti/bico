using Fatec.Domain.Entities.ContractStatus;
using Fatec.Domain.Entities.JobCategory;
using Fatec.Domain.Entities.RequestStatus;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddSeeds(this ModelBuilder builder)
        {
            builder.Entity<JobCategory>()
                .HasData(JobCategory.GenerateSeed());

            builder.Entity<RequestStatus>()
                .HasData(RequestStatus.GenerateSeed());

            builder.Entity<ContractStatus>()
                .HasData(ContractStatus.GenerateSeed());
        }
    }
}
