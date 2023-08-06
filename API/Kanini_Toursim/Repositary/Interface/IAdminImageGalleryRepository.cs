using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Mvc;

public interface IAdminImageGalleryRepository
{
    Task<IEnumerable<AdminImageGallery>> GetAllAdminImageGalleries();
    Task<AdminImageGallery> AdminImageAsync(AdminImageGallery adminImage, IFormFile imageFile);

    Task<AdminImageGallery?> GetAdminImageGalleryById(int id);
    Task<int> CreateAdminImageGallery(AdminImageGallery adminImageGallery);
    Task<bool> UpdateAdminImageGallery(int id, AdminImageGallery adminImageGallery);
    Task<bool> DeleteAdminImageGallery(int id);
}
