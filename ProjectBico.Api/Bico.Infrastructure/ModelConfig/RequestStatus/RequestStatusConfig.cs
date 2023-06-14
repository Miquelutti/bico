using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestStatusEntity = Fatec.Domain.Entities.RequestStatus.RequestStatus;

namespace Fatec.Infrastructure.ModelConfig.RequestStatus
{
    public class RequestStatusConfig : IEntityTypeConfiguration<RequestStatusEntity>
    {
        public void Configure(EntityTypeBuilder<RequestStatusEntity> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(x => x.Requests)
                .WithOne(x => x.RequestStatus)
                .HasForeignKey(x => x.RequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
