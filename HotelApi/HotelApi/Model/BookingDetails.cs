using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Model
{
    public class BookingDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomId { get; set; }

        [ForeignKey("CustomerDetails")]
        public int CustomerId { get; set; }

        //Navigation Property
        public ICollection<CustomerDetails>? customerDetails { get; set; }
    }
}
