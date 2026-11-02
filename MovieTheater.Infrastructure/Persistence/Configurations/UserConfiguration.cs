

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Infrastructure.Persistence.Configurations; 

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure (EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).HasMaxLength(200);
        builder.Property(u => u.Email).HasMaxLength(300);
        builder.Property(u => u.PhoneNumber).HasMaxLength(50);
        builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);
        builder.HasIndex(u => u.Email).IsUnique().HasFilter("[Email] IS NOT NULL");
        builder.HasIndex(u => u.PhoneNumber).IsUnique().HasFilter("[PhoneNumber] IS NOT NULL");

        builder.HasMany(u => u.Bookings)
            .WithOne(b=>b.User)
            .HasForeignKey(b => b.UserId);
    }
}
