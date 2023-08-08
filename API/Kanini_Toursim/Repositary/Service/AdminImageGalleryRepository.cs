using System.Collections.Generic;
using System.Threading.Tasks;
using Kanini_Toursim.Model;
using Kanini_Toursim.Repositary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ImageGallaryServices : IImageGallary
{
    private readonly KaniniTourismDbContext _dbcontext;
    private readonly IWebHostEnvironment _hostEnvironment;

    public ImageGallaryServices(KaniniTourismDbContext dbcontext, IWebHostEnvironment hostEnvironment)
    {
        _dbcontext = dbcontext;
        _hostEnvironment = hostEnvironment;
    }

    public async Task<List<AdminImageGallery>> Postall([FromForm] FileModel aiu)
    {
        string ImagePath = await SaveImage(aiu.FormFile);
        var newAdminImageGalleries = new AdminImageGallery();
        newAdminImageGalleries.UserId = aiu.UserId;
        newAdminImageGalleries.ImagePath = ImagePath;
        newAdminImageGalleries.ImageDetails = aiu.ImageDetail;
        var obj = await _dbcontext.AdminImageGalleries.AddAsync(newAdminImageGalleries);
        await _dbcontext.SaveChangesAsync();
        return await _dbcontext.AdminImageGalleries.ToListAsync();
    }

    [NonAction]
    public async Task<string> SaveImage(IFormFile imageFile)
    {
        try
        {
            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "AdminImage", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine($"Error while saving image in SaveImage method: {ex}");
            throw;
        }
    }

    public async Task<List<AdminImageGallery>> Getall()
    {
        try
        {
            var images = _dbcontext.AdminImageGalleries.ToList();
            var imageList = new List<AdminImageGallery>();
            foreach (var image in images)
            {
                var filePath = Path.Combine(_hostEnvironment.WebRootPath, "AdminImage", image.ImagePath);

                if (File.Exists(filePath))
                {
                    var imageBytes = File.ReadAllBytes(filePath);
                    var tourData = new AdminImageGallery
                    {
                        Id = image.Id,
                        ImageDetails = image.ImageDetails,
                        ImagePath = Convert.ToBase64String(imageBytes)
                    };
                    imageList.Add(tourData);
                }
            }
            return imageList;
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine($"Error while getting all images in ImageGallaryServices: {ex}");
            throw;
        }
    }

    public async Task<AdminImageGallery> Getadminid(int id)
    {
        try
        {
            var byid = _dbcontext.AdminImageGalleries.FirstOrDefault(p => p.Id == id);

            if (byid == null)
            {
                return null;
            }

            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "AdminImage");
            var filePath = Path.Combine(uploadsFolder, byid.ImagePath);

            var imageBytes = await File.ReadAllBytesAsync(filePath);
            var tourData = new AdminImageGallery
            {
                Id = byid.Id,
                ImageDetails = byid.ImageDetails,
                ImagePath = Convert.ToBase64String(imageBytes)
            };

            return tourData;
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine($"Error while getting image by id in ImageGallaryServices: {ex}");
            throw;
        }
    }

    public async Task<AdminImageGallery> Update(int id, [FromForm] FileModel aiu)
    {
        try
        {
            var existingImage = await _dbcontext.AdminImageGalleries.FindAsync(id);

            if (existingImage == null)
            {
                return null;
            }

            if (aiu.FormFile != null)
            {
                string newImageFileName = await SaveImage(aiu.FormFile);
                DeleteImage(existingImage.ImagePath);
                existingImage.ImagePath = newImageFileName;
            }

            existingImage.ImageDetails = aiu.ImageDetail;
            await _dbcontext.SaveChangesAsync();

            return existingImage;
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine($"Error while updating image in ImageGallaryServices: {ex}");
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var existingImage = await _dbcontext.AdminImageGalleries.FindAsync(id);

            if (existingImage == null)
            {
                return false;
            }

            DeleteImage(existingImage.ImagePath);

            _dbcontext.AdminImageGalleries.Remove(existingImage);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine($"Error while deleting image in ImageGallaryServices: {ex}");
            throw;
        }
    }

    [NonAction]
    public void DeleteImage(string imagePath)
    {
        try
        {
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "AdminImage", imagePath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        catch (Exception ex)
        {
            // Log the exception for debugging purposes
            Console.WriteLine($"Error while deleting image in DeleteImage method: {ex}");
            throw;
        }
    }
}
