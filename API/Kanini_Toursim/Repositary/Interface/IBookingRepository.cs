using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;

public interface IBookingRepository
{
    public Task<List<Booking>> GetTripBookings();
    public Task<Booking> GetTripBooking(int id);
    public Task<Booking> PostTripBooking(Booking tripBooking);

}
