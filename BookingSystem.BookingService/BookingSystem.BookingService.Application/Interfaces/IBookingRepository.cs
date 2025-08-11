using BookingSystem.BookingService.Domain.Entities;

namespace BookingSystem.BookingService.Application.Interfaces;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<Booking?> GetByIdAsync(Guid id);
    Task AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(Guid id);
}