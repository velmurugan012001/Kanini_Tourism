using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

public class AdminImageGalleryRepository : IAdminImageGalleryRepository
{
    private readonly KaniniTourismDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminImageGalleryRepository(KaniniTourismDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
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
        existingAdminImageGallery.UserId = adminImageGallery.UserId;
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

    public async Task<AdminImageGallery> AdminImageAsync(AdminImageGallery adminImage, IFormFile imageFile)
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

            adminImage.ImageFile = fileName;

            _context.AdminImageGalleries.Add(adminImage);
            _context.SaveChanges();

            return adminImage;
        }
        catch (Exception ex)
        {

            throw new Exception("Error occurred while posting the room.", ex);
        }

    }
}
