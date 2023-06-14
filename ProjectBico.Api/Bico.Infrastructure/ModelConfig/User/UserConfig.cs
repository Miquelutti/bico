using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserEntity = Fatec.Domain.Entities.User.User;
using AddressEntity = Fatec.Domain.Entities.Address.Address;
using System.Reflection.Emit;

namespace Fatec.Infrastructure.ModelConfig.User
{
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.BirthDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(12);

            builder.HasMany(x => x.Requests)
                .WithOne(x => x.ContractingUser)
                .HasForeignKey(x => x.ContractingUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(x => x.Contracts)
                .WithOne(x => x.ContractingUser)
                .HasForeignKey(x => x.ContractingUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<AddressEntity>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
