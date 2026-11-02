

using MovieTheater.Domain.Enums;

namespace MovieTheater.Domain.Entities;

public class Payment
{
    public int Id { get; set; }

    public int BookingId { get; set; }

    public string Provider { get; set; } = string.Empty;

    public string TransactionId { get; set; } = string.Empty;

    public string? GatewayReference { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; } = string.Empty;

    public PaymentStatus Status { get; set; }

    public DateTime CreatedAtUtc { get; set; }
    public DateTime? CompletedAtUtc { get; set; }
    public string? GatewayResponse { get; set; }
    public Booking Booking { get; set; } = null!;
}
