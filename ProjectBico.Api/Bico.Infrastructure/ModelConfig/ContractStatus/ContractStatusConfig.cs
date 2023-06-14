using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContractStatusEntity = Fatec.Domain.Entities.ContractStatus.ContractStatus;

namespace Fatec.Infrastructure.ModelConfig.ContractStatus
{
    public class ContractStatusConfig : IEntityTypeConfiguration<ContractStatusEntity>
    {
        public void Configure(EntityTypeBuilder<ContractStatusEntity> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Contracts)
                .WithOne(x => x.ContractStatus)
                .HasForeignKey(x => x.ContractStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
