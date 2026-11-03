namespace MovieTheater.Application.Movies.Dtos;

public record MovieCardDto(
    int Id,
    string Title,
    string? PosterUrl,
    int DurationMinutes,
    string Language,
    DateOnly ReleaseDate,
    IReadOnlyList<string> Genres);