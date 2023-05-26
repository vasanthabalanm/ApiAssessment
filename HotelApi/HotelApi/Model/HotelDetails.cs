using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Model
{
    public class HotelDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HotelId { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string HotelDescription { get; set;} = string.Empty;
        public int HotelRoomPrice { get; set;}
        public int HotelRoomsAvailable { get;set;}
        public string HotelLocation { get;set;} = string.Empty;

        //navigation
        public ICollection<HotelAdmin>? HotelAdmins { get; set;}

    }
}
