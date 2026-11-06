namespace MovieTheater.Application.Movies.Dtos;

public record MovieCardDto(
    int Id,
    string Title,
    int DurationMinutes,
    DateOnly ReleaseDate,
    string Language,
    string? PosterUrl,
    
    IReadOnlyList<string> Genres);