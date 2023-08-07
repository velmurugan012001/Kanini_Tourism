using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;



public class PackageRepository : IPackageRepository
{
    private readonly KaniniTourismDbContext _context;

    public PackageRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Package>> GetAllPackages()
    {
        return await _context.Packages.ToListAsync();
    }

    public async Task<Package> GetPackageById(int? id)
    {
        return await _context.Packages.FindAsync(id);
    }

    public async Task<int> CreatePackage(Package package)
    {
        var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.HotalId == package.Hotel.HotalId);
        package.Hotel = hotel; // Update the navigation property

        // Update 'Travel' navigation property if it exists
        if (package.Travel != null && package.Travel.TravelId > 0)
        {
            var travel = await _context.Travels.FirstOrDefaultAsync(x => x.TravelId == package.Travel.TravelId);
            package.Travel = travel;
        }

        // Update 'Activities' navigation property if it exists
        if (package.Activities != null && package.Activities.Count > 0)
        {
            var activityIds = package.Activities.Select(a => a.ActivitiesId).ToList();
            var activities = await _context.Activities.Where(a => activityIds.Contains(a.ActivitiesId)).ToListAsync();
            package.Activities = activities;
        }

        _context.Packages.Add(package);
        await _context.SaveChangesAsync();

        return package.PackageID.HasValue ? package.PackageID.Value : -1; // Return -1 if PackageID is null
    }

    public async Task<bool> UpdatePackage(int? id, Package package)
    {
        if (id == null || package == null)
            return false;

        var existingPackage = await _context.Packages
            .Include(p => p.Hotel) // Include the 'Hotel' navigation property
            .Include(p => p.Travel) // Include the 'Travel' navigation property
            .Include(p => p.Activities) // Include the 'Activities' navigation property
            .FirstOrDefaultAsync(p => p.PackageID == id);

        if (existingPackage == null)
            return false;

        // Update properties accordingly
        existingPackage.OfferingType = package.OfferingType;
        existingPackage.Destination = package.Destination;
        existingPackage.Location = package.Location;
        existingPackage.Days = package.Days;
        existingPackage.Nights = package.Nights;
        existingPackage.Totaldays = package.Totaldays;
        existingPackage.ItineraryDetails = package.ItineraryDetails;
        existingPackage.PricePerPerson = package.PricePerPerson;
        // Update other properties as needed

        // Update the 'Hotel' navigation property if it exists
        if (package.Hotel != null && package.Hotel.HotalId > 0)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.HotalId == package.Hotel.HotalId);
            existingPackage.Hotel = hotel;
        }

        // Update the 'Travel' navigation property if it exists
        if (package.Travel != null && package.Travel.TravelId > 0)
        {
            var travel = await _context.Travels.FirstOrDefaultAsync(x => x.TravelId == package.Travel.TravelId);
            existingPackage.Travel = travel;
        }

        // Update the 'Activities' navigation property if it exists
        if (package.Activities != null && package.Activities.Count > 0)
        {
            var activityIds = package.Activities.Select(a => a.ActivitiesId).ToList();
            var activities = await _context.Activities.Where(a => activityIds.Contains(a.ActivitiesId)).ToListAsync();
            existingPackage.Activities = activities;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePackage(int? id)
    {
        var package = await _context.Packages.FindAsync(id);
        if (package == null)
            return false;

        _context.Packages.Remove(package);
        await _context.SaveChangesAsync();
        return true;
    }
}
