using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostOffice.API.Data.Models;

namespace PostOffice.API.Data.Configurations
{
    public class ParcelTypeConfig : IEntityTypeConfiguration<ParcelType>
    {
        public void Configure(EntityTypeBuilder<ParcelType> builder)
        {
            builder.ToTable("ParcelType");

            builder.HasKey(e => e.id);
            builder.Property(e => e.over_dimension_rate).IsRequired();
            builder.Property(e => e.max_height).IsRequired();
            builder.Property(e => e.max_length).IsRequired();
            builder.Property(e => e.max_width).IsRequired();
            builder.Property(e => e.name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.description)
              .HasMaxLength(500)
              .IsRequired();

        }
    }
}
