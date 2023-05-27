using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Data;
using HotelApi.Model;
using HotelApi.Repository.Customer;
using HotelApi.Repository.HotelDetail;
using Microsoft.AspNetCore.Authorization;

namespace HotelApi.Controller
{
    [Authorize(Roles = "staff")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomer _context;

        public CustomerDetailsController(ICustomer context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails()
        {
            return await _context.GetCustomerDetails();
        }

        // GET: api/CustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(int id)
        {
            try
            {
                var getdt = await _context.GetCustomerDetails(id);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // PUT: api/CustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDetails(int id, CustomerDetails customerDetails)
        {
            try
            {
                var getdt = await _context.PutCustomerDetails(id, customerDetails);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // POST: api/CustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            try
            {
                var getdt = await _context.PostCustomerDetails(customerDetails);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerDetails(int id)
        {
            try
            {
                var getdt = await _context.DeleteCustomerDetails(id);


                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
