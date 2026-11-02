

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations; 

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.TransactionId).IsUnique();

        builder.Property(p => p.Provider).IsRequired().HasMaxLength(128);
        builder.Property(p => p.TransactionId).IsRequired().HasMaxLength(128);
        builder.Property(p => p.Currency).IsRequired().HasMaxLength(3);
        builder.Property(p => p.GatewayReference).HasMaxLength(128);
       
        builder.Property(p=>p.Amount).HasPrecision(10 , 2);

       


              
    }
}
