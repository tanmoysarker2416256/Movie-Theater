

namespace MovieTheater.Domain.Entities; 

public class BookingSeat
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public int ShowId { get; set; }
    public int SeatId { get; set; }

    public bool IsActive { get; set; } = true;

    public decimal Price { get; set; }

    public Booking Booking { get; set; } = null!;

    public Seat Seat { get; set; } = null!;
    public Show Show { get; set; }=null!;
}
