using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Model
{
    public class HotelAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [ForeignKey("HotelDetails")]
        public int HotelId { get; set; }
        public string? StaffName { get; set; }
        public string Staffemail { get; set; } = string.Empty;
        public string StaffPassword { get; set; } = string.Empty;
    }
}
