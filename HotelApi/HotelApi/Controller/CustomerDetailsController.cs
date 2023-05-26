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
    public class CustomerDetailsController : ControllerBase
    {
        private readonly HotelContext _context;

        public CustomerDetailsController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails()
        {
          if (_context.CustomerDetails == null)
          {
              return NotFound();
          }
            return await _context.CustomerDetails.ToListAsync();
        }

        // GET: api/CustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(int id)
        {
          if (_context.CustomerDetails == null)
          {
              return NotFound();
          }
            var customerDetails = await _context.CustomerDetails.FindAsync(id);

            if (customerDetails == null)
            {
                return NotFound();
            }

            return customerDetails;
        }

        // PUT: api/CustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetails(int id, CustomerDetails customerDetails)
        {
            if (id != customerDetails.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDetailsExists(id))
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

        // POST: api/CustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
          if (_context.CustomerDetails == null)
          {
              return Problem("Entity set 'HotelContext.CustomerDetails'  is null.");
          }
            _context.CustomerDetails.Add(customerDetails);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerDetailsExists(customerDetails.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerDetails", new { id = customerDetails.CustomerId }, customerDetails);
        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetails(int id)
        {
            if (_context.CustomerDetails == null)
            {
                return NotFound();
            }
            var customerDetails = await _context.CustomerDetails.FindAsync(id);
            if (customerDetails == null)
            {
                return NotFound();
            }

            _context.CustomerDetails.Remove(customerDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerDetailsExists(int id)
        {
            return (_context.CustomerDetails?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
