

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).IsRequired().HasMaxLength(200);
        builder.Property(m => m.Synopsis).HasMaxLength(3000);
        builder.Property(m => m.PosterUrl).HasMaxLength(500);
         builder.Property(m => m.TrailerUrl).HasMaxLength(500);
        builder.Property(m => m.Language).IsRequired().HasMaxLength(100);

        builder.HasMany(m => m.Shows)
            .WithOne(s => s.Movie)
            .HasForeignKey(s => s.MovieId);

        builder.HasMany(m => m.MovieGenres)
            .WithOne(mg => mg.Movie)
            .HasForeignKey(mg =>  mg.MovieId);

            

            
           
    }
}
