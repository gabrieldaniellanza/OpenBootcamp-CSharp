using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Helpers;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers.V1
{
    [ApiVersion(Version.V)]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IStringLocalizer<AccountsController> _stringLocalizer;

        private readonly JwtSettings _jwtSettings;

        private readonly UniversityDBContext _context;

        public AccountsController(UniversityDBContext context, JwtSettings jwtSettings, IStringLocalizer<AccountsController> stringLocalizer)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            _stringLocalizer = stringLocalizer;

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


        [MapToApiVersion(Version.V)]
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var Saludo = string.Empty;

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

                var searchUser = (from user in _context.Users
                                 where user.Name.Equals(userLogins.UserName) &&
                                        user.Password.Equals(userLogins.Password)
                                 select user).FirstOrDefault();

                Console.WriteLine("User: {0}", searchUser);

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

                    Saludo = _stringLocalizer.GetString("Hello!").Value ?? String.Empty;
                }
                else
                {
                    return BadRequest("Wrong Password");
                }

                return Ok( new
                {
                    Token,
                    Saludo
                });

            }
            catch (Exception)
            {
                throw new Exception("GetToken Error");
            }

        }


        [MapToApiVersion(Version.V)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUsersList()
        {

            var searchUser = (from user in _context.Users
                              select user);

            return Ok(searchUser);
        }
    }
}
