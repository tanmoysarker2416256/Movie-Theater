
using Microsoft.EntityFrameworkCore;
using MovieTheater.Domain.Entities;
using MovieTheater.Application.Abstractions;

namespace MovieTheater.Infrastructure.Persistence;

public class MovieTheaterDbContext : DbContext , IApplicationDbContext
{
    public MovieTheaterDbContext(DbContextOptions<MovieTheaterDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieTheaterDbContext).Assembly);
    }


    public DbSet<Cinema> Cinemas => Set<Cinema>();
    public DbSet<Hall> Halls => Set<Hall>();
    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<BookingSeat> BookingSeats => Set<BookingSeat>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<MovieGenre> MovieGenres => Set<MovieGenre>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Seat> Seats => Set<Seat>();
    public DbSet<Show> Shows => Set<Show>();
    public DbSet<User> Users => Set<User>();



}
