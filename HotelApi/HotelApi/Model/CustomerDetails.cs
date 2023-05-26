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
        [Phone]
        public string? CustomerPhone { get; set; }
        public string CustomerCity { get; set; } = string.Empty;

        public int CustomerCount { get; set; }
        //navigation to bookingdetails
        public ICollection<BookingDetails>? Bookings { get; set; }

        

    }
    
}
