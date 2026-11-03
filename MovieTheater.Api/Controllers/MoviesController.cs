using Microsoft.AspNetCore.Mvc;
using MovieTheater.Application.Movies;
using MovieTheater.Application.Movies.Dtos;

namespace MovieTheater.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
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
}