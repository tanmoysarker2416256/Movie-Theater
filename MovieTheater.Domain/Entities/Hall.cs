using MovieTheater.Domain.Enums;


namespace MovieTheater.Domain.Entities;

public class Hall
{
    public int Id { get; set; }
    public int CinemaId { get; set; }

    public string Name { get; set; } = string.Empty;


    public HallType HallType { get; set; }

    public Cinema Cinema { get; set; } = null!;

    public ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public ICollection<Show> Shows { get; set; }= new List<Show>();


}
