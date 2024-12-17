﻿using Microsoft.EntityFrameworkCore;
using UltraGroupHotels.Domain.Hotels;

namespace UltraGroupHotels.Infrastructure.Persistence.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly ApplicationDbContext _context;

    public HotelRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Hotel hotel)
    {
        _context.Hotels.Add(hotel);
    }

    public void Delete(Hotel hotel)
    {
        _context.Hotels.Remove(hotel);
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var exists = _context.Hotels.AnyAsync(h => h.Id == id, cancellationToken);

        return exists;
    }

    public async Task<List<Hotel>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var hotels = await _context.Hotels.ToListAsync(cancellationToken);

        return hotels;
    }

    public async Task<Hotel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.Id == id, cancellationToken);


        return hotel;
    }

    public void Update(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
    }
}
