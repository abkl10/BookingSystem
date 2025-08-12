using BookingSystem.BookingService.Application.Interfaces;
using BookingSystem.BookingService.Domain.Entities;
using BookingSystem.BookingService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.BookingService.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly BookingDbContext _context;
    public BookingRepository(BookingDbContext context) => _context = context;

    public async Task AddAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var existing = await _context.Bookings.FindAsync(id);
        if (existing is not null)
        {
            _context.Bookings.Remove(existing);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
        => await _context.Bookings.ToListAsync();

    public async Task<Booking?> GetByIdAsync(Guid id)
        => await _context.Bookings.FindAsync(id);

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }
}