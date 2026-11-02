

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations;

public class BookingSeatConfiguration : IEntityTypeConfiguration<BookingSeat>
{
    public void Configure(EntityTypeBuilder<BookingSeat> builder)
    {

        builder.ToTable("BookingSeats");
        builder.HasKey(bs => bs.Id);

        builder.Property(bs => bs.Price).HasPrecision(10, 2);

        builder.HasIndex(bs => new { bs.SeatId, bs.ShowId })
               .IsUnique()
                .HasFilter("[IsActive] = 1");

        builder.HasOne(bs => bs.Seat)
               .WithMany()
                .HasForeignKey(bs => bs.SeatId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(bs => bs.Show)
               .WithMany()
               .HasForeignKey(bs => bs.ShowId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
