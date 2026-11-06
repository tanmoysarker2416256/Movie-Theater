using Microsoft.EntityFrameworkCore;
using MovieTheater.Domain.Entities;

namespace MovieTheater.Application.Abstractions;

public interface IApplicationDbContext
{
    DbSet<Movie> Movies { get; }
    DbSet<Show> Shows { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}