using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class BookingRepository : IBookingRepository
{
    private readonly KaniniTourismDbContext _dbcontext;

    public BookingRepository(KaniniTourismDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<List<Booking>> GetTripBookings()
    {
        return await _dbcontext.Bookings.ToListAsync();
    }

    public async Task<Booking> GetTripBooking(int id)
    {
        return await _dbcontext.Bookings.FindAsync(id);
    }

    public async Task<Booking> PostTripBooking(Booking tripBooking)
    {
        var addedBooking = await _dbcontext.Bookings.AddAsync(tripBooking);
        await _dbcontext.SaveChangesAsync();
        return addedBooking.Entity;
    }
}
