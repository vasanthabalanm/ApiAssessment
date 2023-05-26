using HotelApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Repository.Booking
{
    public interface IBooking
    {
        Task<ActionResult<IEnumerable<BookingDetails>>> GetBookingDetails();
        Task<BookingDetails> GetBookingDetails(int id);
        Task<BookingDetails> PutBookingDetails(int id, BookingDetails bookingDetails);
        Task<ActionResult<BookingDetails>> PostBookingDetails(BookingDetails bookingDetails);
        Task<string> DeleteBookingDetails(int id);
    }
}
