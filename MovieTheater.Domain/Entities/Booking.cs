

using MovieTheater.Domain.Enums;

namespace MovieTheater.Domain.Entities;

public class Booking
{
    public int Id { get; set; }

    public string BookingCode { get; set; } = string.Empty;

    public int UserId { get; set; }

    public int ShowId { get; set; }

    public BookingStatus Status { get; set; }
    public decimal TotalAmount { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime ExpiresAtUtc { get; set; }

    public DateTime? ConfirmedAtUtc { get; set; }

    public User User { get; set; } = null!;
    public Show Show { get; set; } = null!;

    public ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

}
