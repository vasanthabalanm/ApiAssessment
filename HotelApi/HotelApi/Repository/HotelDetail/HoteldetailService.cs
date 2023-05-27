using HotelApi.Data;
using HotelApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repository.HotelDetail
{
    public class HoteldetailService : IHoteldetails
    {
        private readonly HotelContext _context;

        public HoteldetailService(HotelContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<HotelDetails>>> GetHotelDetails()
        {
            //to return as list
            var getdt = await _context.HotelDetails.ToListAsync();
            return getdt;
        }
        public async Task<HotelDetails> GetHotelDetails(int id)
        {
            //fetch the hotelid in the hoteldetails table
            var getdt = await _context.HotelDetails.FirstOrDefaultAsync(hotelid => hotelid.HotelId== id);
            if(getdt==null)
            {
                throw new ArithmeticException("The given HotelId is Not available! Try again");
            }
            return getdt;
        }
        public async Task<HotelDetails> PutHotelDetails(int id, HotelDetails hotelDetails)
        {
            var getdt =  await _context.HotelDetails.FindAsync(id);
            if (getdt == null)
            {
                throw new ArithmeticException("The given HotelId is Not available! Try again");
            }
            getdt.HotelName = hotelDetails.HotelName;
            getdt.HotelDescription = hotelDetails.HotelDescription;
            getdt.HotelRoomPrice = hotelDetails.HotelRoomPrice;
            getdt.HotelRoomsAvailable = hotelDetails.HotelRoomsAvailable;
            getdt.HotelLocation = hotelDetails.HotelLocation;

            await _context.SaveChangesAsync();
            return getdt;
        }
        public async Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails)
        {
            _context.Add(hotelDetails);
            await _context.SaveChangesAsync();
            return hotelDetails;
        }
        public async Task<string> DeleteHotelDetails(int id)
        {
            var getdt = await _context.HotelDetails.FirstOrDefaultAsync(hotelid => hotelid.HotelId == id);
             _context.Remove(getdt);
            await _context.SaveChangesAsync();
            return "Deleted done";
        }
        /*public async Task<List<HotelDetails>> GetHotelLocationDetails(int price)
         {
             /* var getdt = await _context.HotelDetails.FirstOrDefaultAsync(hotelid => hotelid.HotelRoomPrice <= price);

              return getdt.HotelLocation;
             var locat = await(from Getlocate in _context.HotelDetails where Getlocate.HotelRoomPrice < price select Getlocate).ToListAsync();
             return locat;


         }*/
        public async Task<List<HotelDetails>> FilterHotels(string location, decimal minPrice, decimal maxPrice)
        {
            var query = _context.HotelDetails.AsQueryable();

            // Apply filters based on criteria
            if (!string.IsNullOrEmpty(location))
                query = query.Where(h => h.HotelLocation == location);

            if (minPrice >= 0)
                query = query.Where(h => h.HotelRoomPrice >= minPrice);

            if (maxPrice > minPrice)
                query = query.Where(h => h.HotelRoomPrice <= maxPrice);

            // Execute the query asynchronously and return the filtered hotels
            return await query.ToListAsync();
        }


    }
}
