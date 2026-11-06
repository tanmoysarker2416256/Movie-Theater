using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Movies;
using MovieTheater.Application.Movies.Dtos;
using MovieTheater.Application.Shows;
using MovieTheater.Application.Shows.Dtos;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;
    private readonly ShowService _showService;

    public MoviesController(MovieService movieService , ShowService showService)
    {
        _movieService = movieService;
        _showService = showService;
    }

    [HttpGet("now-showing")]
    public async Task<ActionResult<List<MovieCardDto>>> GetNowShowing(CancellationToken ct)
    {
        var movies = await _movieService.GetNowShowingAsync(ct);
        return Ok(movies);
    }
    [HttpGet("coming-soon")]

    public async Task<ActionResult<List<MovieCardDto>>> GetComingSoon (CancellationToken ct)
    {
        var movies = await _movieService.GetComingSoonAsync(ct);
        return Ok(movies);
    }

    [HttpGet("{id:int}")]

    public async Task<ActionResult<MovieDetailsDto>> GetDetails (int id , CancellationToken ct )
    {
        var movie = await _movieService.GetDetailsAsync(id, ct);
        if(movie == null)
            return NotFound();

        return Ok(movie);
    }
    [HttpGet("{id:int}/shows")]
    public async Task<ActionResult<List<ShowSummaryDto>>> GetShows(
    int id, DateOnly? date, CancellationToken ct)
    {
        var day = date ?? DateOnly.FromDateTime(DateTime.UtcNow.AddHours(6));
        var shows = await _showService.GetShowsForMovieAsync(id, day, ct);
        return Ok(shows);
    }

}