using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Abstractions;
using MovieTheater.Application.Movies.Dtos;
using MovieTheater.Domain.Enums;

namespace MovieTheater.Application.Movies;

public class MovieService
{
    private readonly IApplicationDbContext _db;

    public MovieService(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<MovieCardDto>> GetNowShowingAsync(CancellationToken ct)
    {
        var now = DateTime.UtcNow;
        var today = DateOnly.FromDateTime(now);

        return await _db.Movies
            .AsNoTracking()
            .Where(m => m.ReleaseDate <= today &&
                        m.Shows.Any(s => s.Status == ShowStatus.Scheduled && s.StartTimeUtc >= now))
            .OrderBy(m => m.Title)
            .Select(m => new MovieCardDto(
                m.Id,
                m.Title,
                 m.DurationMinutes,
                 m.ReleaseDate,
                  m.Language,
                m.PosterUrl,


                m.MovieGenres.Select(mg => mg.Genre.Name).ToList()))

            .ToListAsync(ct);
    }

    public async Task<List<MovieCardDto>> GetComingSoonAsync(CancellationToken ct)
    {

        var today = DateOnly.FromDateTime(DateTime.UtcNow);

        return await _db.Movies
            .AsNoTracking()
            .Where(m => m.ReleaseDate > today)
            .OrderBy(m => m.ReleaseDate)
            .Select(m => new MovieCardDto(
                m.Id,
                m.Title,
                 m.DurationMinutes,
                    m.ReleaseDate,
                      m.Language,
                m.PosterUrl,
               
              
             
                m.MovieGenres.Select(mg => mg.Genre.Name).ToList()))
            .ToListAsync(ct);

    }

    public async Task<MovieDetailsDto?> GetDetailsAsync(int id , CancellationToken ct)
    {
         return await _db.Movies
            .AsNoTracking()
            .Where (m => m.Id == id)
            .Select(m=>new MovieDetailsDto(
                m.Id,
                m.Title,
                m.Synopsis,
                m.DurationMinutes,
                m.ReleaseDate,
                m.Language,
                m.PosterUrl,
                m.TrailerUrl,
                m.MovieGenres.Select(mg=>mg.Genre.Name).ToList()))
            .FirstOrDefaultAsync(ct);
    }
}