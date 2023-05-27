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
using Microsoft.AspNetCore.Authorization;

namespace HotelApi.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDetailsController : ControllerBase
    {
        private readonly IHoteldetails _context;

        public HotelDetailsController(IHoteldetails context)
        {
            _context = context;
        }
                
        
        // GET: api/HotelDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDetails>>> GetHotelDetails()
        {
            return await _context.GetHotelDetails();
        }


        // GET: api/HotelDetails/5
        [HttpGet("{id}")]
        [Authorize(Roles = "owner")]
        public async Task<ActionResult<HotelDetails>> GetHotelDetails(int id)
        {
            try
            {
                var getdt = await _context.GetHotelDetails();
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }


        // PUT: api/HotelDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "owner")]
        public async Task<IActionResult> PutHotelDetails(int id, HotelDetails hotelDetails)
        {
            try
            {
                var getdt = await _context.PutHotelDetails(id,hotelDetails);
                return Ok(getdt);
            }
            catch (ArithmeticException ex )
            {
                return NotFound(ex.Message);

            }
        }
        
        // POST: api/HotelDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "owner")]
        [Authorize (Roles ="Owner")]
        public async Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails)
        {
            try
            {
                var getdt = await _context.PostHotelDetails(hotelDetails);
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        // DELETE: api/HotelDetails/5
        [HttpDelete("{hotelid}")]
        [Authorize(Roles = "owner")]
        public async Task<ActionResult<string>> DeleteHotelDetails(int hotelid)
        {
            try
            {
                var getdt = await _context.DeleteHotelDetails(hotelid);

              
                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

        //filter
        [HttpGet("filter")]
        public async Task<IActionResult> FilterHotels([FromQuery] string location, [FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var filteredHotels =await  _context.FilterHotels(location,minPrice,maxPrice);
            return Ok(filteredHotels);
        }

        //count the available rooms
        [HttpGet("{hotelId}/count")]
        public async Task<IActionResult> GetAvailableRoomCount(int hotelId)
        {
            var availableRoomCount = await _context.GetAvailableRoomCountAsync(hotelId);
            return Ok(availableRoomCount);
        }



    }
}
