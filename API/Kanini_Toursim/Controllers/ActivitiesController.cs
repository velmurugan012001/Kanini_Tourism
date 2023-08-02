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
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesRepository _repository;

        public ActivitiesController(IActivitiesRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activities>>> GetActivities()
        {
            var activities = await _repository.GetAllActivities();
            return Ok(activities);
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activities>> GetActivities(int id)
        {
            var activity = await _repository.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivities(int id, Activities activity)
        {
            if (id != activity.ActivitiesId)
            {
                return BadRequest();
            }

            var success = await _repository.UpdateActivity(id, activity);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostActivities(Activities activity)
        {
            var id = await _repository.CreateActivity(activity);
            return CreatedAtAction("GetActivities", new { id = id }, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivities(int id)
        {
            var success = await _repository.DeleteActivity(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
