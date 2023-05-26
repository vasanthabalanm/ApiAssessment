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
       
                
        //to view the location of the hotel
        [HttpGet("{price}")]
        public async Task<ActionResult<List<HotelDetails>>> GetHotelLocationDetails(int price)
        {
            try
            {
                var getdt = await _context.DeleteHotelDetails(price);


                return Ok(getdt);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }
        }

    }
}
