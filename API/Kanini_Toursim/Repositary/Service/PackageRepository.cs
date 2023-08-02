﻿using System.Collections.Generic;
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

    public async Task<Package?> GetPackageById(int? id)
    {
        return await _context.Packages.FindAsync(id);
    }

    public async Task<int> CreatePackage(Package package)
    {
        _context.Packages.Add(package);
        await _context.SaveChangesAsync();
        return package.PackageID ?? 0;
    }

    public async Task<bool> UpdatePackage(int? id, Package package)
    {
        if (id == null || package == null)
            return false;

        var existingPackage = await _context.Packages.FindAsync(id);
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
        existingPackage.HotalId = package.HotalId;
        existingPackage.TravelId = package.TravelId;
        existingPackage.ActivitiesId = package.ActivitiesId;
        // Update other properties as needed

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