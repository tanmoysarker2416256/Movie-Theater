

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations;

public class CineplexConfiguration : IEntityTypeConfiguration<Cineplex>
{
    public void Configure(EntityTypeBuilder<Cineplex> builder)
    {
        builder.ToTable("Cineplexs");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Phone).HasMaxLength(20);
        builder.Property(c => c.Address).IsRequired().HasMaxLength(200);

        builder.HasMany(c => c.Halls)
               .WithOne(h => h.Cineplex)
               .HasForeignKey(h => h.CineplexId);

    }

}
