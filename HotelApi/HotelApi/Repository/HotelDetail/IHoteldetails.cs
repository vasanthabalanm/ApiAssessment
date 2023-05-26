using HotelApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Repository.HotelDetail
{
    public interface IHoteldetails
    {
        Task<ActionResult<IEnumerable<HotelDetails>>> GetHotelDetails();
        Task<HotelDetails> GetHotelDetails(int id);
        Task<HotelDetails> PutHotelDetails(int id, HotelDetails hotelDetails);
        Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails);
        Task<string> DeleteHotelDetails(int id);
        //Task<ActionResult<HotelDetails>> GetHotelLocationDetails(int price);
    }
}
