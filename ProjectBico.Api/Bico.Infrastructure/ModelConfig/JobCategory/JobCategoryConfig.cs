using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JobCategoryEntity = Fatec.Domain.Entities.JobCategory.JobCategory;

namespace Fatec.Infrastructure.ModelConfig.JobCategory
{
    public class JobCategoryConfig : IEntityTypeConfiguration<JobCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<JobCategoryEntity> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Jobs)
                .WithOne(x => x.JobCategory)
                .HasForeignKey(x => x.JobCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
