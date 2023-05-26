using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Data;
using HotelApi.Model;

namespace HotelApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDetailsController : ControllerBase
    {
        private readonly HotelContext _context;

        public HotelDetailsController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/HotelDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDetails>>> GetHotelDetails()
        {
          if (_context.HotelDetails == null)
          {
              return NotFound();
          }
            return await _context.HotelDetails.ToListAsync();
        }

        // GET: api/HotelDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDetails>> GetHotelDetails(int id)
        {
          if (_context.HotelDetails == null)
          {
              return NotFound();
          }
            var hotelDetails = await _context.HotelDetails.FindAsync(id);

            if (hotelDetails == null)
            {
                return NotFound();
            }

            return hotelDetails;
        }

        // PUT: api/HotelDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelDetails(int id, HotelDetails hotelDetails)
        {
            if (id != hotelDetails.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(hotelDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HotelDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails)
        {
          if (_context.HotelDetails == null)
          {
              return Problem("Entity set 'HotelContext.HotelDetails'  is null.");
          }
            _context.HotelDetails.Add(hotelDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HotelDetailsExists(hotelDetails.HotelId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHotelDetails", new { id = hotelDetails.HotelId }, hotelDetails);
        }

        // DELETE: api/HotelDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelDetails(int id)
        {
            if (_context.HotelDetails == null)
            {
                return NotFound();
            }
            var hotelDetails = await _context.HotelDetails.FindAsync(id);
            if (hotelDetails == null)
            {
                return NotFound();
            }

            _context.HotelDetails.Remove(hotelDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelDetailsExists(int id)
        {
            return (_context.HotelDetails?.Any(e => e.HotelId == id)).GetValueOrDefault();
        }
    }
}
