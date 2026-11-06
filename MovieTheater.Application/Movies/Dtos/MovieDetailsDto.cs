

namespace MovieTheater.Application.Movies.Dtos;


public record MovieDetailsDto(
    int Id,
    string Title,
    string? Synopsis,
     int DurationMinutes,
     DateOnly ReleaseDate,
      string Language,
    string? PosterUrl,
    string? TrailerUrl,
    IReadOnlyList<string> Genres
    );

