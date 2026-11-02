

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations; 

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{

    public void Configure (EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seats");
        builder.HasKey(s => s.Id);
        builder.Property(s=>s.RowLabel).IsRequired().HasMaxLength(10);
        builder.HasIndex(s => new { s.HallId, s.Number, s.RowLabel }).IsUnique();
    }
}
