

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations; 

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure (EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.BookingCode).IsRequired().HasMaxLength(20);
        builder.HasIndex(b => b.BookingCode).IsUnique();
        builder.Property(b => b.TotalAmount).HasPrecision(10,2);

        builder.HasMany(b => b.BookingSeats)
            .WithOne(bs => bs.Booking)
            .HasForeignKey(bs => bs.BookingId);

        builder.HasMany(b =>b.Payments)
            .WithOne(p => p.Booking)
            .HasForeignKey(p => p.BookingId);
       

    }
}
