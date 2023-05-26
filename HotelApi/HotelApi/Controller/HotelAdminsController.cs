using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelApi.Data;
using HotelApi.Model;
using HotelApi.Repository.HotelDetail;
using HotelApi.Repository.HotelAdminRepo;
using Microsoft.AspNetCore.Authorization;

namespace HotelApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles ="staff")]
    public class HotelAdminsController : ControllerBase
    {
        private readonly IAdmins _context;

        public HotelAdminsController(IAdmins context)
        {
            _context = context;
        }
    
        // GET: api/HotelAdmins
        [HttpGet]
        public async Task<ActionResult<List<HotelAdmin>>> GetHotelAdmins()
        {
            var i= await _context.GetHotelAdmins();
            return Ok(i);
        }
        

        // PUT: api/HotelAdmins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelAdmin(int id, HotelAdmin hotelAdmin)
        {
            try
            {
                var getdt = await _context.PutHotelAdmin(id, hotelAdmin);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }

        }

        // POST: api/HotelAdmins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelAdmin>> PostHotelAdmin(HotelAdmin hotelAdmin)
        {
            try
            {
                var getdt = await _context.PostHotelAdmin(hotelAdmin);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // DELETE: api/HotelAdmins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelAdmin(int id)
        {
            try
            {
                var getdt = await _context.DeleteHotelAdmin(id);


                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
