

using MovieTheater.Domain.Enums;

namespace MovieTheater.Domain.Entities; 

public class Seat
{
     public int Id { get; set; }
    public int HallId {  get; set; }

    public string RowLabel { get; set; } = string.Empty;

    public int Number { get; set; }    

    public SeatType SeatType { get; set; }

    public Hall Hall { get; set; } = null!;
}
