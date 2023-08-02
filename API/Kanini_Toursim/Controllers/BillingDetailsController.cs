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
    public class BillingDetailsController : ControllerBase
    {
        private readonly IBillingDetailsRepository _repository;

        public BillingDetailsController(IBillingDetailsRepository repository)
        {
            _repository = repository;
        }

        // GET: api/BillingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillingDetails>>> GetBillingDetails()
        {
            var billingDetails = await _repository.GetAllBillingDetails();
            return Ok(billingDetails);
        }

        // GET: api/BillingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillingDetails>> GetBillingDetails(int id)
        {
            var billingDetails = await _repository.GetBillingDetailsById(id);
            if (billingDetails == null)
            {
                return NotFound();
            }

            return Ok(billingDetails);
        }

        // PUT: api/BillingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillingDetails(int id, BillingDetails billingDetails)
        {
            if (id != billingDetails.BillingId)
            {
                return BadRequest();
            }

            var success = await _repository.UpdateBillingDetails(id, billingDetails);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/BillingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostBillingDetails(BillingDetails billingDetails)
        {
            var id = await _repository.CreateBillingDetails(billingDetails);
            return CreatedAtAction("GetBillingDetails", new { id = id }, billingDetails);
        }

        // DELETE: api/BillingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillingDetails(int id)
        {
            var success = await _repository.DeleteBillingDetails(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
