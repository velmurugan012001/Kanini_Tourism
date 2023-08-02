using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kanini_Toursim.Model;

namespace Kanini_Toursim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminImageGalleriesController : ControllerBase
    {
        private readonly IAdminImageGalleryRepository _repository;

        public AdminImageGalleriesController(IAdminImageGalleryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/AdminImageGalleries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminImageGallery>>> GetAdminImageGalleries()
        {
            var adminImageGalleries = await _repository.GetAllAdminImageGalleries();
            return Ok(adminImageGalleries);
        }

        // GET: api/AdminImageGalleries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminImageGallery>> GetAdminImageGallery(int id)
        {
            var adminImageGallery = await _repository.GetAdminImageGalleryById(id);
            if (adminImageGallery == null)
            {
                return NotFound();
            }

            return Ok(adminImageGallery);
        }

        // PUT: api/AdminImageGalleries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminImageGallery(int id, AdminImageGallery adminImageGallery)
        {
            if (id != adminImageGallery.AdminImgsId)
            {
                return BadRequest();
            }

            var success = await _repository.UpdateAdminImageGallery(id, adminImageGallery);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/AdminImageGalleries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAdminImageGallery(AdminImageGallery adminImageGallery)
        {
            var id = await _repository.CreateAdminImageGallery(adminImageGallery);
            return CreatedAtAction("GetAdminImageGallery", new { id = id }, adminImageGallery);
        }

        // DELETE: api/AdminImageGalleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminImageGallery(int id)
        {
            var success = await _repository.DeleteAdminImageGallery(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
