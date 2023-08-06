using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


public class AdminUserRepository : IAdminUserRepository
{
    private readonly KaniniTourismDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public AdminUserRepository(KaniniTourismDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IEnumerable<Admin_User>> GetAllAdminUsers()
    {
        return await _context.AdminUsers.ToListAsync();
    }

    public async Task<Admin_User?> GetAdminUserById(int id)
    {
        return await _context.AdminUsers.FindAsync(id);
    }

    public async Task<int> CreateAdminUser(Admin_User adminUser)
    {
        _context.AdminUsers.Add(adminUser);
        await _context.SaveChangesAsync();
        return adminUser.UserId;
    }

    public async Task<bool> UpdateAdminUser(int id, Admin_User adminUser)
    {
        var existingAdminUser = await _context.AdminUsers.FindAsync(id);
        if (existingAdminUser == null)
            return false;

        // Update properties accordingly
        existingAdminUser.Username = adminUser.Username;
        existingAdminUser.Email = adminUser.Email;
        existingAdminUser.Password = adminUser.Password;
        existingAdminUser.Role = adminUser.Role;
        existingAdminUser.Address = adminUser.Address;
        existingAdminUser.Phone = adminUser.Phone;
        existingAdminUser.AgencyName = adminUser.AgencyName;
        existingAdminUser.IDproofFileName = adminUser.IDproofFileName;
        // Update other properties as needed

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAdminUser(int id)
    {
        var adminUser = await _context.AdminUsers.FindAsync(id);
        if (adminUser == null)
            return false;

        _context.AdminUsers.Remove(adminUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Admin_User> UserAsync(Admin_User user, IFormFile imageFile)
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

            user.IDproof = fileName;
            
            _context.AdminUsers.Add(user);
            _context.SaveChanges();

            return user;
        }
        catch (Exception ex)
        {

            throw new Exception("Error occurred while posting the room.", ex);
        }

    }
}
