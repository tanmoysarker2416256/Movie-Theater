using System;

namespace MovieTheater.Domain.Entities;

public class Cinema
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? Phone { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<Hall> Halls { get; set; } = new List<Hall>();
}