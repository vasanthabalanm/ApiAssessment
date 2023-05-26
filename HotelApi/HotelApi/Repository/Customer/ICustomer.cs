using HotelApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Repository.Customer
{
    public interface ICustomer
    {
        Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails();
        Task<CustomerDetails> GetCustomerDetails(int id);
        Task<CustomerDetails> PutCustomerDetails(int id, CustomerDetails customerDetails);
        Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails);
        Task<string> DeleteCustomerDetails(int id);
    }
}
