using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;

public interface IBookingRepository
{
    Task<IEnumerable<Booking>> GetAllBookings();
    Task<Booking?> GetBookingById(int id);
    Task<int> CreateBooking(Booking booking);
    Task<bool> UpdateBooking(int id, Booking booking);
    Task<bool> DeleteBooking(int id);
}
