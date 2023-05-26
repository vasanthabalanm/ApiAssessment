using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Data;
using HotelApi.Model;
using HotelApi.Repository.Booking;
using HotelApi.Repository.HotelDetail;

namespace HotelApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly IBooking _context;

        public BookingDetailsController(IBooking context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetails>>> GetBookingDetails()
        {
            return await _context.GetBookingDetails();
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetails>> GetBookingDetails(int id)
        {
            try
            {
                var getdt = await _context.GetBookingDetails(id);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetails(int id, BookingDetails bookingDetails)
        {
            try
            {
                var getdt = await _context.PutBookingDetails(id, bookingDetails);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // POST: api/BookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookingDetails>> PostBookingDetails(BookingDetails bookingDetails)
        {
            try
            {
                var getdt = await _context.PostBookingDetails(bookingDetails);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteBookingDetails(int id)
        {
            try
            {
                var getdt = await _context.DeleteBookingDetails(id);


                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
