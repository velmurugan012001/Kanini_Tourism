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
    public class Admin_UserController : ControllerBase
    {
        private readonly IAdminUserRepository _repository;

        public Admin_UserController(IAdminUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Admin_User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin_User>>> GetAdminUsers()
        {
            var adminUsers = await _repository.GetAllAdminUsers();
            return Ok(adminUsers);
        }

        // GET: api/Admin_User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin_User>> GetAdmin_User(int id)
        {
            var adminUser = await _repository.GetAdminUserById(id);
            if (adminUser == null)
            {
                return NotFound();
            }

            return Ok(adminUser);
        }

        // PUT: api/Admin_User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin_User(int id, Admin_User admin_User)
        {
            if (id != admin_User.Id)
            {
                return BadRequest();
            }

            var success = await _repository.UpdateAdminUser(id, admin_User);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Admin_User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostAdmin_User(Admin_User admin_User)
        {
            var id = await _repository.CreateAdminUser(admin_User);
            return CreatedAtAction("GetAdmin_User", new { id = id }, admin_User);
        }

        // DELETE: api/Admin_User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin_User(int id)
        {
            var success = await _repository.DeleteAdminUser(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
