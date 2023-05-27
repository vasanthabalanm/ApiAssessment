using HotelApi.Data;
using HotelApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffToken : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly HotelContext _projectContext;

        public StaffToken(IConfiguration config, HotelContext context)
        {
            _config = config;
            _projectContext = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(HotelAdmin _staffInfo)
        {
            if (_staffInfo != null && _staffInfo.Staffemail != null && _staffInfo.StaffPassword != null)
            {
                var staff = await GetStaff(_staffInfo.Staffemail, _staffInfo.StaffPassword);

                if (staff != null)
                {
                    // Create claims details based on the staff information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("StaffId", staff.StaffId.ToString()),
                        new Claim("Email", staff.Staffemail),
                        new Claim("Password",staff.StaffPassword),
                        new Claim("Role", "staff")
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<HotelAdmin> GetStaff(string email, string password)
        {
            return await _projectContext.HotelAdmins.FirstOrDefaultAsync(info => info.Staffemail == email && info.StaffPassword == password);
        }
    }
}
