

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations; 

public class ShowConfiguration : IEntityTypeConfiguration<Show>
{
    public void Configure(EntityTypeBuilder<Show> builder)
    {
        builder.ToTable("Shows");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.BasePrice).HasPrecision(10, 2);

        builder.HasMany(s => s.Bookings)
            .WithOne(b => b.Show)
            .HasForeignKey(b => b.ShowId);
    }
}
