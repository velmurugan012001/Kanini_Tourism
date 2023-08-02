using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.EntityFrameworkCore;

public class AdminImageGalleryRepository : IAdminImageGalleryRepository
{
    private readonly KaniniTourismDbContext _context;

    public AdminImageGalleryRepository(KaniniTourismDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AdminImageGallery>> GetAllAdminImageGalleries()
    {
        return await _context.AdminImageGalleries.ToListAsync();
    }

    public async Task<AdminImageGallery?> GetAdminImageGalleryById(int id)
    {
        return await _context.AdminImageGalleries.FindAsync(id);
    }

    public async Task<int> CreateAdminImageGallery(AdminImageGallery adminImageGallery)
    {
        _context.AdminImageGalleries.Add(adminImageGallery);
        await _context.SaveChangesAsync();
        return adminImageGallery.AdminImgsId;
    }

    public async Task<bool> UpdateAdminImageGallery(int id, AdminImageGallery adminImageGallery)
    {
        var existingAdminImageGallery = await _context.AdminImageGalleries.FindAsync(id);
        if (existingAdminImageGallery == null)
            return false;

        // Update properties accordingly
        existingAdminImageGallery.Id = adminImageGallery.Id;
        existingAdminImageGallery.LocationName = adminImageGallery.LocationName;
        existingAdminImageGallery.LocationDescription = adminImageGallery.LocationDescription;
        existingAdminImageGallery.ImageName = adminImageGallery.ImageName;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAdminImageGallery(int id)
    {
        var adminImageGallery = await _context.AdminImageGalleries.FindAsync(id);
        if (adminImageGallery == null)
            return false;

        _context.AdminImageGalleries.Remove(adminImageGallery);
        await _context.SaveChangesAsync();
        return true;
    }
}
