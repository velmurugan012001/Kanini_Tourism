using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class BookingRepository : IBookingRepository
{
    private readonly KaniniTourismDbContext _context;

    public BookingRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetAllBookings()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async Task<Booking?> GetBookingById(int id)
    {
        return await _context.Bookings.FindAsync(id);
    }

    public async Task<int> CreateBooking(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking.BookingId;
    }

    public async Task<bool> UpdateBooking(int id, Booking booking)
    {
        var existingBooking = await _context.Bookings.FindAsync(id);
        if (existingBooking == null)
            return false;

        // Update properties accordingly
        existingBooking.Id = booking.Id;
        existingBooking.PackageID = booking.PackageID;
        existingBooking.DateOfTravel = booking.DateOfTravel;
        existingBooking.NumberOfPeople = booking.NumberOfPeople;
        existingBooking.TotalCost = booking.TotalCost;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBooking(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking == null)
            return false;

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return true;
    }
}
