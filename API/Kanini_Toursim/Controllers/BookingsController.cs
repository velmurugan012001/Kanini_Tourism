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
    public class TripBookingsController : ControllerBase
    {
        private readonly IBookingRepository _context;

        public TripBookingsController(IBookingRepository context)
        {
            _context = context;
        }

        // GET: api/TripBookings
        [HttpGet]
        public async Task<ActionResult<List<IBookingRepository>>> GetTripBookings()
        {
            try
            {
                return Ok(await _context.GetTripBookings());
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/TripBookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IBookingRepository>> GetTripBooking(int id)
        {
            try
            {
                return Ok(await _context.GetTripBooking(id));
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);
            }
        }



        // POST: api/TripBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostTripBooking(Booking tripBooking)
        {
            return await _context.PostTripBooking(tripBooking);

        }


    }
}