using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestEntity = Fatec.Domain.Entities.Request.Request;
using ContractEntity = Fatec.Domain.Entities.Contract.Contract;

namespace Fatec.Infrastructure.ModelConfig.Request
{
    public class RequestConfig : IEntityTypeConfiguration<RequestEntity>
    {
        public void Configure(EntityTypeBuilder<RequestEntity> builder)
        {
            builder.Property(x => x.ApprovalDate)
                .HasColumnType("datetime");

            builder.Property(x => x.RejectionDate)
                .HasColumnType("datetime");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.EndDate)
                .HasColumnType("datetime");

            builder.HasOne(x => x.ContractingUser)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.ContractingUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.RequestStatus)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.RequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Contract)
                .WithOne(x => x.Request)
                .HasForeignKey<ContractEntity>(x => x.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
