using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        private readonly UniversityDBContext _context;

        public AccountsController(UniversityDBContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        private readonly IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "uno@gmail.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "dos@gmail.com",
                Name = "User1",
                Password = "Dos"
            }
        };


        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                if (_context.Users == null)
                {
                    return NotFound();
                }

                /*var Valid = Logins.Any(
                                user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase) &&
                                        user.Password.Equals(userLogins.Password, StringComparison.OrdinalIgnoreCase));*/

                var Valid = _context.Users.Any(
                                user => user.Name.Equals(userLogins.UserName) &&
                                        user.Password.Equals(userLogins.Password));

                if (Valid)
                {
                    /*var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));*/

                    var user = _context.Users.FirstOrDefault(
                        user => 
                            user.Name.Equals(userLogins.UserName) && user.Password.Equals(userLogins.Password));

                    if (user == null)
                    {
                        return NotFound();
                    }

                    Token = JwtHelpers.GenTokenKey(
                        new UserTokens()
                        {
                            UserName = user.Name,
                            EmailId = user.Email,
                            Id = user.Id,
                            GuidId = Guid.NewGuid()
                        },
                        _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong Password");
                }

                return Ok(Token);

            }
            catch (Exception ex)
            {
                throw new Exception("GetToken Error");
            }

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUsersList()
        {
            return Ok(Logins);
        }
    }
}
