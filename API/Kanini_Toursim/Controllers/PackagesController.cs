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
    public class PackagesController : ControllerBase
    {
        private readonly IPackageRepository _repository;

        public PackagesController(IPackageRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
        {
            var packages = await _repository.GetAllPackages();
            return Ok(packages);
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int? id)
        {
            var package = await _repository.GetPackageById(id);
            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int? id, Package package)
        {
            if (id != package.PackageID)
            {
                return BadRequest();
            }

            var success = await _repository.UpdatePackage(id, package);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostPackage(Package package)
        {
            var id = await _repository.CreatePackage(package);
            return CreatedAtAction("GetPackage", new { id = id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int? id)
        {
            var success = await _repository.DeletePackage(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
