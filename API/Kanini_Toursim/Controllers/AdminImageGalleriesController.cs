using Kanini_Toursim.Model;
using Kanini_Toursim.Repositary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Travel.Models;
using Travel.Repository.Interface;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageGallaryController : ControllerBase
    {
        private readonly IImageGallary _context;

        public ImageGallaryController(IImageGallary context)
        {
            _context = context;
        }

        [HttpPost("AllAdminColumn")]
        public async Task<ActionResult<List<AdminImageGallery>>> Postall([FromForm] FileModel aiu)
        {
            try
            {
                return await _context.Postall(aiu);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error while posting all images in ImageGallaryController: {ex}");
                throw;
            }
        }

        [HttpGet("GetAllDetailsFromAdminTable")]
        public async Task<ActionResult<List<AdminImageGallery>>> Getall()
        {
            try
            {
                var images = await _context.Getall();
                if (images == null)
                {
                    return NotFound();
                }
                return new JsonResult(images);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error while getting all images in ImageGallaryController: {ex}");
                throw;
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<AdminImageGallery>> Getadminid(int id)
        {
            try
            {
                var images = await _context.Getadminid(id);
                if (images == null)
                {
                    return NotFound();
                }
                return new JsonResult(images);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error while getting image by id in ImageGallaryController: {ex}");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var isDeleted = await _context.Delete(id);

                if (!isDeleted)
                {
                    return NotFound();
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error while deleting image in ImageGallaryController: {ex}");
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdminImageGallery>> Put(int id, [FromForm] FileModel aiu)
        {
            try
            {
                var updatedImage = await _context.Update(id, aiu);

                if (updatedImage == null)
                {
                    return NotFound();
                }

                return Ok(updatedImage);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                Console.WriteLine($"Error while updating image in ImageGallaryController: {ex}");
                throw;
            }
        }
    }
}