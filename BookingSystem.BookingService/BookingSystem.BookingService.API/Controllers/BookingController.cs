using BookingSystem.BookingService.Application.DTOs;
using BookingSystem.BookingService.Application.Interfaces;
using BookingSystem.BookingService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookingSystem.BookingService.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingRepository _repo;

    public BookingController(IBookingRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var b = await _repo.GetByIdAsync(id);
        return b is null ? NotFound() : Ok(b);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookingDto dto)
    {
        var booking = new Booking
        {
            UserId = Guid.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!),
            ServiceType = dto.ServiceType,
            BookingDate = dto.BookingDate,
            Price = dto.Price
        };

        await _repo.AddAsync(booking);
        return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateBookingDto dto)
    {
        var booking = await _repo.GetByIdAsync(id);
        if (booking is null) return NotFound();

        booking.ServiceType = dto.ServiceType;
        booking.Price = dto.Price;
        booking.BookingDate = dto.BookingDate;
        booking.Status = dto.Status;

        await _repo.UpdateAsync(booking);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}