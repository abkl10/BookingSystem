using BookingSystem.BookingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.BookingService.Infrastructure.Persistence;

public class BookingDbContext : DbContext
{
    public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

    public DbSet<Booking> Bookings => Set<Booking>();
}