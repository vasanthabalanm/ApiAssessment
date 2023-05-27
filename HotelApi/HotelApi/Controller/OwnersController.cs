using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.AuthUser;
using HotelApi.Data;
using Microsoft.AspNetCore.Authorization;

namespace HotelApi.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly OwnerContext _context;

        public OwnersController(OwnerContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var owner = await _context.Users.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        // PUT: api/Owners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, Owner owner)
        {
            if (id != owner.UserId)
            {
                return BadRequest();
            }

            _context.Entry(owner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
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

        // POST: api/Owners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'OwnerContext.Users'  is null.");
          }
            _context.Users.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOwner", new { id = owner.UserId }, owner);
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var owner = await _context.Users.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Users.Remove(owner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OwnerExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
