

namespace MovieTheater.Application.Shows.Dtos; 

public record ShowSummaryDto(
    int ShowId,
    string HallName,
    DateTime StartTimeUtc ,
    DateTime EndTimeUtc,
    decimal Price,
    int AvailableSeats
    );

