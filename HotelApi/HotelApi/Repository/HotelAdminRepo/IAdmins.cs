using HotelApi.Model;
using Microsoft.AspNetCore.Mvc;



namespace HotelApi.Repository.HotelAdminRepo

{
    public interface IAdmins
    {
        Task<List<HotelAdmin>> GetHotelAdmins();
        Task<HotelAdmin> PutHotelAdmin(int id, HotelAdmin hotelAdmin);
        Task<HotelAdmin> PostHotelAdmin(HotelAdmin hotelAdmin);
        Task<string> DeleteHotelAdmin(int id);

    }
}
