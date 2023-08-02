using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;

public interface IHotelRepository
{
    Task<IEnumerable<Hotel>> GetAllHotels();
    Task<Hotel?> GetHotelById(int id);
    Task<int> CreateHotel(Hotel hotel);
    Task<bool> UpdateHotel(int id, Hotel hotel);
    Task<bool> DeleteHotel(int id);
}
