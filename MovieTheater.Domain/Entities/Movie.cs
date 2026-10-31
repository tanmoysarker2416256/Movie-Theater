

namespace MovieTheater.Domain.Entities; 

public class Movie
{

    public int Id { get; set; }

    public string Title { get; set; }=string.Empty;

    public string? Synopsis { get; set; }

    public int DurationMinutes { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string Language { get; set; } = string.Empty;

    public string? PosterUrl { get; set; }
    public string? TrailerUrl { get; set; } 

    public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
}
