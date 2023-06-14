using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AddressEntity = Fatec.Domain.Entities.Address.Address;
using UserEntity = Fatec.Domain.Entities.User.User;

namespace Fatec.Infrastructure.ModelConfig.Address
{
    public class AddressConfig : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.Property(x => x.CEP)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
