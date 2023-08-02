using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class HotelRepository : IHotelRepository
{
    private readonly KaniniTourismDbContext _context;

    public HotelRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Hotel>> GetAllHotels()
    {
        return await _context.Hotels.ToListAsync();
    }

    public async Task<Hotel?> GetHotelById(int id)
    {
        return await _context.Hotels.FindAsync(id);
    }

    public async Task<int> CreateHotel(Hotel hotel)
    {
        _context.Hotels.Add(hotel);
        await _context.SaveChangesAsync();
        return hotel.HotalId;
    }

    public async Task<bool> UpdateHotel(int id, Hotel hotel)
    {
        var existingHotel = await _context.Hotels.FindAsync(id);
        if (existingHotel == null)
            return false;

        // Update properties accordingly
        existingHotel.Name = hotel.Name;
        existingHotel.Place = hotel.Place;
        existingHotel.FoodType = hotel.FoodType;
        existingHotel.BedType = hotel.BedType;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteHotel(int id)
    {
        var hotel = await _context.Hotels.FindAsync(id);
        if (hotel == null)
            return false;

        _context.Hotels.Remove(hotel);
        await _context.SaveChangesAsync();
        return true;
    }
}
