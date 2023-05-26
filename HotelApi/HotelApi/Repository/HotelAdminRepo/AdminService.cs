using HotelApi.Data;
using HotelApi.Model;
using HotelApi.Repository.HotelDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repository.HotelAdminRepo
{
    public class AdminService : IAdmins
    {
        private readonly HotelContext _context;

        public AdminService(HotelContext context)
        {
            _context = context;
        }
        public async Task<List<HotelAdmin>> GetHotelAdmins()
        {
            //to return as list
            var getdt = await _context.HotelAdmins.ToListAsync();
            return getdt;
        }
        public async Task<HotelAdmin> PutHotelAdmin(int id, HotelAdmin hotelAdmin)
        {
            var getdt = await _context.HotelAdmins.FindAsync(id);
            if (getdt == null)
            {
                throw new ArithmeticException("The given HotelId is Not available! Try again");
            }
            getdt.HotelId = hotelAdmin.HotelId;
            getdt.StaffName = hotelAdmin.StaffName;
            getdt.Staffemail = hotelAdmin.Staffemail;
            getdt.StaffPassword = hotelAdmin.StaffPassword;
            await _context.SaveChangesAsync();
            return getdt;
        }
        public async Task<HotelAdmin> PostHotelAdmin(HotelAdmin hotelAdmin)
        {
            _context.Add(hotelAdmin);
            await _context.SaveChangesAsync();
            return hotelAdmin;
        }
        public async Task<string> DeleteHotelAdmin(int id)
        {
            var getdt = await _context.HotelAdmins.FirstOrDefaultAsync(stafid => stafid.StaffId == id);
            _context.Remove(getdt);
            await _context.SaveChangesAsync();
            return "Deleted done";
        }


    }
}
