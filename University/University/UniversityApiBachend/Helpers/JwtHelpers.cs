using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserTokens userAccount, Guid Id )
        {
            List<Claim> claims = new List<Claim>()
            { 
                new Claim("Id", userAccount.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.Email, userAccount.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt")),
                new Claim(ClaimTypes.Role, userAccount.Rol.ToString())
            };

            //claims.Add(new Claim(ClaimTypes.Role, userAccount.Rol.ToString()));

            if (userAccount.Rol == Roles.Administrador)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserTokens userAccount, out Guid Id)
        {

            Id = Guid.NewGuid();

            return GetClaims(userAccount, Id);

        }

        public static UserTokens GenTokenKey(UserTokens model, JwtSettings jwtSettings)
        {
            var userToken = new UserTokens();

            try
            {
                
                if (model == null)
                    throw new ArgumentException(nameof(model));

                var key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IssuerSigningKey);


                Guid Id;

                // Expira en un dia
                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // Valides
                userToken.Validity = expireTime.TimeOfDay;

                // Generamos nuestro JWT
                var jwtToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidUssuer,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
                    );

                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.EmailId = model.EmailId;
                userToken.GuidId = Id;

                return userToken;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el jwt", ex);
            }

        }

    }
}
