using HotelApi.Data;
using HotelApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repository.Booking
{
    public class BookingService : IBooking
    {
        private readonly HotelContext _context;
        public BookingService(HotelContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<BookingDetails>>> GetBookingDetails()

        {
            //to return as list
            var getdt = await _context.BookingDetails.ToListAsync();
            return getdt;
        }
        public async Task<BookingDetails> GetBookingDetails(int id)

        {
            //fetch the hotelid in the hoteldetails table
            var getdt = await _context.BookingDetails.FirstOrDefaultAsync(bookid => bookid.BookingId == id);
            if (getdt == null)
            {
                throw new ArithmeticException("The given HotelId is Not available! Try again");
            }
            return getdt;
        }
        public async Task<BookingDetails> PutBookingDetails(int id, BookingDetails bookingDetails)
        {
            var getdt = await _context.BookingDetails.FindAsync(id);
            if (getdt == null)
            {
                throw new ArithmeticException("The given HotelId is Not available! Try again");
            }
            getdt.RoomId = bookingDetails.RoomId;
            getdt.CustomerId = bookingDetails.CustomerId;

            await _context.SaveChangesAsync();
            return getdt;
        }
        public async Task<ActionResult<BookingDetails>> PostBookingDetails(BookingDetails bookingDetails)
        {
            _context.Add(bookingDetails);
            await _context.SaveChangesAsync();
            return bookingDetails;
        }
        public async Task<string> DeleteBookingDetails(int id)
        {
            var getdt = await _context.BookingDetails.FirstOrDefaultAsync(bookid => bookid.BookingId == id);
            _context.Remove(getdt);
            await _context.SaveChangesAsync();
            return "Deleted done";
        }
    }
}
