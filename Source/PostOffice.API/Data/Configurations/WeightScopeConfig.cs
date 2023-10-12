using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PostOffice.API.Data.Models;

namespace PostOffice.API.Data.Configurations
{
    public class WeightScopeConfig : IEntityTypeConfiguration<WeightScope>
    {
        public void Configure(EntityTypeBuilder<WeightScope> builder)
        {
            builder.ToTable("WeightScope");

            builder.Property(e => e.id).HasColumnName("id");
            builder.Property(e => e.description)
                .HasMaxLength(50)
                .HasColumnName("description");
            builder.Property(e => e.max_weight).IsRequired();
            builder.Property(e => e.min_weight).IsRequired();
        }
    }
}
