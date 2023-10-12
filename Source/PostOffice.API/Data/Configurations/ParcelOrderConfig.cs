using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostOffice.API.Data.Models;

namespace PostOffice.API.Data.Configurations
{
    public class ParcelOrderConfig : IEntityTypeConfiguration<ParcelOrder>
    {
        public void Configure(EntityTypeBuilder<ParcelOrder> builder)
        {
            builder.ToTable("ParcelOrder");

            builder.HasKey(e => e.id);
          /*  builder.Property(e => e.receive_date)
                .IsRowVersion()
                .IsConcurrencyToken()
                .IsRequired();*/
            builder.Property(e => e.description)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(e => e.note)
                .HasMaxLength(50)
                .IsRequired();
           /* builder.Property(e => e.send_date)
                .IsRowVersion()
                .IsConcurrencyToken()
                .IsRequired();*/
            builder.Property(e => e.order_status)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(e => e.parcel_height).IsRequired();
            builder.Property(e => e.parcel_height).IsRequired();
           /* builder.Property(e => e.parcel_type_id).IsRequired();*/
            builder.Property(e => e.parcel_weight).IsRequired();
            builder.Property(e => e.parcel_width).IsRequired();
            builder.Property(e => e.payment_method)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(e => e.payer)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(e => e.receiver_address)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(e => e.receiver_email)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.receiver_name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.receiver_phone)
                .HasMaxLength(50)
                .IsRequired();
           
            builder.Property(e => e.sender_address)
                .HasMaxLength(200)
                .IsRequired();
            builder.Property(e => e.sender_email)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.sender_name)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e => e.sender_phone)
                .HasMaxLength(20)
                .IsRequired();            
            
            builder.Property(e => e.total_charge).IsRequired();
            builder.Property(e => e.vpp_value).IsRequired();

        
            builder.HasOne(d => d.ParcelSenderPincode)
       .WithMany(p => p.SenderPincodePO)
       .HasForeignKey(d => d.sender_pincode).OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(d => d.ParcelReceiverPincode)
       .WithMany(p => p.ReceiverPincodePO)
       .HasForeignKey(d => d.receiver_pincode).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(d => d.TrackHistories).WithOne(p => p.ParcelOrder)
              .HasForeignKey(d => d.order_id)
              .OnDelete(DeleteBehavior.NoAction);
             

        }
    }
}
