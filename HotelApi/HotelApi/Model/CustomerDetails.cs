using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Model
{
    public class CustomerDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public Int128 CustomerPhone { get; set; }
        public string CustomerCity { get; set; } = string.Empty;

        public int CustomerCount { get; set; }
        //navigation to bookingdetails
        public BookingDetails? Bookings { get; set; }

        

    }
    
}
