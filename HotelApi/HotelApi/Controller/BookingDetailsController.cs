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
    public class BookingDetailsController : ControllerBase
    {
        private readonly HotelContext _context;

        public BookingDetailsController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetails>>> GetBookingDetails()
        {
          if (_context.BookingDetails == null)
          {
              return NotFound();
          }
            return await _context.BookingDetails.ToListAsync();
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetails>> GetBookingDetails(int id)
        {
          if (_context.BookingDetails == null)
          {
              return NotFound();
          }
            var bookingDetails = await _context.BookingDetails.FindAsync(id);

            if (bookingDetails == null)
            {
                return NotFound();
            }

            return bookingDetails;
        }

        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetails(int id, BookingDetails bookingDetails)
        {
            if (id != bookingDetails.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailsExists(id))
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

        // POST: api/BookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingDetails>> PostBookingDetails(BookingDetails bookingDetails)
        {
          if (_context.BookingDetails == null)
          {
              return Problem("Entity set 'HotelContext.BookingDetails'  is null.");
          }
            _context.BookingDetails.Add(bookingDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingDetailsExists(bookingDetails.BookingId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookingDetails", new { id = bookingDetails.BookingId }, bookingDetails);
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingDetails(int id)
        {
            if (_context.BookingDetails == null)
            {
                return NotFound();
            }
            var bookingDetails = await _context.BookingDetails.FindAsync(id);
            if (bookingDetails == null)
            {
                return NotFound();
            }

            _context.BookingDetails.Remove(bookingDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingDetailsExists(int id)
        {
            return (_context.BookingDetails?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
