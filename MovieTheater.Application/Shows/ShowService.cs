

using Microsoft.EntityFrameworkCore;
using MovieTheater.Application.Abstractions;
using MovieTheater.Application.Shows.Dtos;
using MovieTheater.Domain.Enums;

namespace MovieTheater.Application.Shows;

public class ShowService
{
    private readonly IApplicationDbContext _db;

    public ShowService(IApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<ShowSummaryDto>> GetShowsForMovieAsync(
    int movieId, DateOnly date, CancellationToken ct)
    {
        var localOffset = TimeSpan.FromHours(6);
        var startUtc = date.ToDateTime(TimeOnly.MinValue) - localOffset;
        var endUtc = startUtc.AddDays(1);
        var now = DateTime.UtcNow;

        return await _db.Shows
            .AsNoTracking()
            .Where(s => s.MovieId == movieId &&
                        s.Status == ShowStatus.Scheduled &&
                        s.StartTimeUtc >= startUtc && s.StartTimeUtc < endUtc &&
                        s.StartTimeUtc >= now)
            .OrderBy(s => s.StartTimeUtc)
            .Select(s => new ShowSummaryDto(
                s.Id,
                s.Hall.Name,
                s.StartTimeUtc,
                s.EndTimeUtc,
                s.BasePrice,
                s.Hall.Seats.Count() - s.Bookings
                    .Where(b => b.Status == BookingStatus.Confirmed ||
                                (b.Status == BookingStatus.Pending && b.ExpiresAtUtc > now))
                    .SelectMany(b => b.BookingSeats)
                    .Count(bs => bs.IsActive)))
            .ToListAsync(ct);
    }

}
