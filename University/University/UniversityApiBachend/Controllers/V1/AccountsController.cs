using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Reflection;
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

        private readonly ILogger<AccountsController> _logger;

        public AccountsController(
            UniversityDBContext context, 
            JwtSettings jwtSettings, 
            IStringLocalizer<AccountsController> stringLocalizer, 
            ILogger<AccountsController> logger)
        {
            _context = context;
            _jwtSettings = jwtSettings;
            _stringLocalizer = stringLocalizer;
            _logger = logger;

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
        public async Task<IActionResult> GetToken(UserLogins userLogins)
        {

            //_logger.LogTrace($"{nameof(AccountsController)} - {nameof(GetToken)} - Trace log level");
            //_logger.LogDebug($"{nameof(AccountsController)} - {nameof(GetToken)} - Debug log level");
            //_logger.LogInformation($"{nameof(AccountsController)} - {nameof(GetToken)} - Information log level");
            //_logger.LogWarning($"{nameof(AccountsController)} - {nameof(GetToken)} - Warning log level");
            //_logger.LogError($"{nameof(AccountsController)} - {nameof(GetToken)} - Error log level");
            //_logger.LogCritical($"{nameof(AccountsController)} - {nameof(GetToken)} - Critical log level");

            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

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

                var Valid = await _context.Users.AnyAsync(
                                user => user.Name.Equals(userLogins.UserName) &&
                                        user.Password.Equals(userLogins.Password));

                var searchUser = await (from user in _context.Users
                                 where user.Name.Equals(userLogins.UserName) &&
                                        user.Password.Equals(userLogins.Password)
                                 select user).FirstOrDefaultAsync();

                Console.WriteLine("User: {0}", searchUser);

                if (Valid)
                {
                    /*var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogins.UserName, StringComparison.OrdinalIgnoreCase));*/

                    var user = await _context.Users.FirstOrDefaultAsync(
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
            catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }

        }


        [MapToApiVersion(Version.V)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> GetUsersList()
        {

            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            var searchUser = await (from user in _context.Users
                              select user).FirstOrDefaultAsync();

            return Ok(searchUser);
        }
    }
}
