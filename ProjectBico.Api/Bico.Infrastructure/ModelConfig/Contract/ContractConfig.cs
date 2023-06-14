using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContractEntity = Fatec.Domain.Entities.Contract.Contract;
using RequestEntity = Fatec.Domain.Entities.Request.Request;

namespace Fatec.Infrastructure.ModelConfig.Contract
{
    public class ContractConfig : IEntityTypeConfiguration<ContractEntity>
    {
        public void Configure(EntityTypeBuilder<ContractEntity> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Price);

            builder.Property(x => x.StartTime)
                .IsRequired();

            builder.Property(x => x.EndTime)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.EndDate)
                .HasColumnType("datetime");

            builder.Property(x => x.TotalDays)
                .IsRequired();

            builder.Property(x => x.Evaluation);

            builder.HasOne(x => x.ContractingUser)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.ContractingUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Request)
                .WithOne(x => x.Contract)
                .HasForeignKey<RequestEntity>(x => x.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.ContractStatus)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.ContractStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
