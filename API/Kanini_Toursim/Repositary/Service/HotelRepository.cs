using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

public class HotelRepository : IHotelRepository
{
    private readonly KaniniTourismDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HotelRepository(KaniniTourismDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
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

    public async Task<Hotel> HotelAsync(Hotel hotel, IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new ArgumentException("Invalid file");
        }

        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(uploadsFolder, fileName);
        try
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            hotel.Image = fileName;

            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            return hotel;
        }
        catch (Exception ex)
        {

            throw new Exception("Error occurred while posting the room.", ex);
        }

    }
}
