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
    public class HotelAdminsController : ControllerBase
    {
        private readonly HotelContext _context;

        public HotelAdminsController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/HotelAdmins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelAdmin>>> GetHotelAdmins()
        {
          if (_context.HotelAdmins == null)
          {
              return NotFound();
          }
            return await _context.HotelAdmins.ToListAsync();
        }

        // GET: api/HotelAdmins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelAdmin>> GetHotelAdmin(int id)
        {
          if (_context.HotelAdmins == null)
          {
              return NotFound();
          }
            var hotelAdmin = await _context.HotelAdmins.FindAsync(id);

            if (hotelAdmin == null)
            {
                return NotFound();
            }

            return hotelAdmin;
        }

        // PUT: api/HotelAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAdmin(int id, HotelAdmin hotelAdmin)
        {
            if (id != hotelAdmin.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(hotelAdmin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelAdminExists(id))
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

        // POST: api/HotelAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelAdmin>> PostHotelAdmin(HotelAdmin hotelAdmin)
        {
          if (_context.HotelAdmins == null)
          {
              return Problem("Entity set 'HotelContext.HotelAdmins'  is null.");
          }
            _context.HotelAdmins.Add(hotelAdmin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelAdmin", new { id = hotelAdmin.StaffId }, hotelAdmin);
        }

        // DELETE: api/HotelAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAdmin(int id)
        {
            if (_context.HotelAdmins == null)
            {
                return NotFound();
            }
            var hotelAdmin = await _context.HotelAdmins.FindAsync(id);
            if (hotelAdmin == null)
            {
                return NotFound();
            }

            _context.HotelAdmins.Remove(hotelAdmin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelAdminExists(int id)
        {
            return (_context.HotelAdmins?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
