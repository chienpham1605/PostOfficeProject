using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostOffice.API.Data.Models;

namespace PostOffice.API.Data.Configurations
{
    public class ParcelServiceConfig:  IEntityTypeConfiguration<ParcelService>
    {
        public void Configure(EntityTypeBuilder<ParcelService> builder)
        {
            builder.ToTable("ParcelServices");
            builder.HasKey(p => p.service_id);
            builder.Property(p => p.name).IsRequired();
            builder.Property(p => p.description).IsRequired();
            builder.Property(p => p.delivery_time).IsRequired();
            builder.Property(p => p.status).IsRequired();

            builder.HasMany(e => e.ParcelOrders)
                .WithOne(o => o.ParcelService).HasForeignKey(o => o.service_id);

        }
    }
}
