/*using System;
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
    public class TravelsController : ControllerBase
    {
        private readonly ITravelRepository _repository;

        public TravelsController(ITravelRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Travels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travel>>> GetTravels()
        {
            var travels = await _repository.GetAllTravels();
            return Ok(travels);
        }

        // GET: api/Travels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Travel>> GetTravel(int id)
        {
            var travel = await _repository.GetTravelById(id);
            if (travel == null)
            {
                return NotFound();
            }

            return Ok(travel);
        }

        // PUT: api/Travels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravel(int id, Travel travel)
        {
            if (id != travel.TravelId)
            {
                return BadRequest();
            }

            var success = await _repository.UpdateTravel(id, travel);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Travels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostTravel(Travel travel)
        {
            var id = await _repository.CreateTravel(travel);
            return CreatedAtAction("GetTravel", new { id = id }, travel);
        }

        // DELETE: api/Travels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravel(int id)
        {
            var success = await _repository.DeleteTravel(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
*/