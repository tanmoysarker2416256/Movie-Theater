

using MovieTheater.Domain.Enums;

namespace MovieTheater.Domain.Entities; 

public class User
{

    public int Id { get; set; }
    public string? Email { get; set; }
    

    public string? PhoneNumber { get; set; }   

    public string PasswordHash { get; set; } = string.Empty;
    
    public UserRole Role { get; set; }
    public string? Name { get; set; } 

    public DateTime CreatedAtUtc { get; set; }
    public ICollection<Booking> Bookings { get; set; }=new List<Booking>();





}
