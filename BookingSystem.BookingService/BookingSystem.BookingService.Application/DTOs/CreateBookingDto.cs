using System.ComponentModel.DataAnnotations;

namespace BookingSystem.BookingService.Application.DTOs;

public class CreateBookingDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public string ServiceType { get; set; } = string.Empty;

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

    public decimal Price { get; set; } = 0;
}