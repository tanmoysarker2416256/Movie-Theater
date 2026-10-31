

using MovieTheater.Domain.Enums;

namespace MovieTheater.Domain.Entities;

public class Show
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int HallId { get; set; }

    public DateTime StartTimeUtc { get; set; }
    public DateTime EndTimeUtc { get; set; }

    public decimal BasePrice { get; set; }

    public ShowStatus Status { get; set; }

    public Movie Movie { get; set; } = null!; 
    public Hall Hall { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

}
