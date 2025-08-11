namespace BookingSystem.BookingService.Application.DTOs;

public class UpdateBookingDto : CreateBookingDto
{
    public string Status { get; set; } = "Pending";
}