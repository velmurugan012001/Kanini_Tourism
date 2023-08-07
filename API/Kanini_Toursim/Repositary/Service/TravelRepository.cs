/*using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class TravelRepository : ITravelRepository
{
    private readonly KaniniTourismDbContext _context;

    public TravelRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Travel>> GetAllTravels()
    {
        return await _context.Travels.ToListAsync();
    }

    public async Task<Travel?> GetTravelById(int id)
    {
        return await _context.Travels.FindAsync(id);
    }

    public async Task<int> CreateTravel(Travel travel)
    {
        _context.Travels.Add(travel);
        await _context.SaveChangesAsync();
        return travel.TravelId;
    }

    public async Task<bool> UpdateTravel(int id, Travel travel)
    {
        var existingTravel = await _context.Travels.FindAsync(id);
        if (existingTravel == null)
            return false;

        // Update properties accordingly
        existingTravel.VehicleType = travel.VehicleType;
        existingTravel.ToDate = travel.ToDate;
        existingTravel.FromDate = travel.FromDate;
        existingTravel.Facilities = travel.Facilities;
        existingTravel.Itinerary = travel.Itinerary;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTravel(int id)
    {
        var travel = await _context.Travels.FindAsync(id);
        if (travel == null)
            return false;

        _context.Travels.Remove(travel);
        await _context.SaveChangesAsync();
        return true;
    }
}
*/