using System.ComponentModel.DataAnnotations;

namespace HotelApi.AuthUser
{
    public class Owner
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }

        public string EmailId { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Roles { get; set; } = string.Empty;
    }
}
