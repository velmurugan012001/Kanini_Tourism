using Kanini_Toursim.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Kanini_Toursim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageRepository _packageRepository;

        public PackageController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        // GET: api/Package
        [HttpGet]
        public ActionResult<IEnumerable<Package>> GetAllPackages()
        {
            var packages = _packageRepository.GetAllPackages();
            return Ok(packages);
        }

        // GET: api/Package/5
        [HttpGet("{packageId}")]
        public ActionResult<Package> GetPackageById(int packageId)
        {
            var package = _packageRepository.GetPackageById(packageId);

            if (package == null)
            {
                return NotFound();
            }

            return Ok(package);
        }

        // POST: api/Package
        [HttpPost]
        public ActionResult AddPackage([FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _packageRepository.AddPackage(package);
            return CreatedAtAction(nameof(GetPackageById), new { packageId = package.PackageID }, package);
        }

        // PUT: api/Package/5
        [HttpPut("{packageId}")]
        public IActionResult UpdatePackage(int packageId, [FromBody] Package updatedPackage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var package = _packageRepository.GetPackageById(packageId);
            if (package == null)
            {
                return NotFound();
            }

            _packageRepository.UpdatePackage(packageId, updatedPackage);
            return NoContent();
        }

        // DELETE: api/Package/5
        [HttpDelete("{packageId}")]
        public IActionResult DeletePackage(int packageId)
        {
            var package = _packageRepository.GetPackageById(packageId);
            if (package == null)
            {
                return NotFound();
            }

            _packageRepository.DeletePackage(packageId);
            return NoContent();
        }
    }
}
