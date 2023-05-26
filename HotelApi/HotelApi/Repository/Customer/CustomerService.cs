using HotelApi.Data;
using HotelApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Repository.Customer
{
    public class CustomerService : ICustomer
    {
        private readonly HotelContext _context;

        public CustomerService(HotelContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails()

        {
            //to return as list
            var getdt = await _context.CustomerDetails.ToListAsync();
            return getdt;
        }
        public async Task<CustomerDetails> GetCustomerDetails(int id)

        {
            //fetch the hotelid in the hoteldetails table
            var getdt = await _context.CustomerDetails.FirstOrDefaultAsync(cusid => cusid.CustomerId == id);
            if (getdt == null)
            {
                throw new ArithmeticException("The given HotelId is Not available! Try again");
            }
            return getdt;
        }
        public async Task<CustomerDetails> PutCustomerDetails(int id, CustomerDetails customerDetails)
        {
            var getdt = await _context.CustomerDetails.FindAsync(id);
            if (getdt == null)
            {
                throw new ArithmeticException("The given HotelId is Not available! Try again");
            }
            getdt.CustomerName = customerDetails.CustomerName;
            getdt.CustomerEmail = customerDetails.CustomerEmail;
            getdt.CustomerPhone = customerDetails.CustomerPhone;
            getdt.CustomerCity = customerDetails.CustomerCity;           

            await _context.SaveChangesAsync();
            return getdt;
        }
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            _context.Add(customerDetails);
            await _context.SaveChangesAsync();
            return customerDetails;
        }
        public async Task<string> DeleteCustomerDetails(int id)
        {
            var getdt = await _context.CustomerDetails.FirstOrDefaultAsync(cusid => cusid.CustomerId == id);
            _context.Remove(getdt);
            await _context.SaveChangesAsync();
            return "Deleted done";
        }
    }
}
