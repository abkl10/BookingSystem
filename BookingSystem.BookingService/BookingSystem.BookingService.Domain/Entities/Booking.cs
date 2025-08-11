namespace BookingSystem.BookingService.Domain.Entities;

public class Booking
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid UserId { get; set; }

    public string ServiceType { get; set; } = string.Empty;

    public DateTime BookingDate { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = "Pending"; 
}