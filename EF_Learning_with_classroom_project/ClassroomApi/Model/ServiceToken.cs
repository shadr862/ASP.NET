using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClassroomApi.Model
{
    public class ServiceToken
    {
        private readonly IConfiguration _configuration;

        public ServiceToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       
        public static string GenerateServiceToken(IConfiguration jwtConfiguration)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfiguration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var listClaims = new List<Claim>()
                  {
                      new Claim(JwtRegisteredClaimNames.Sub, jwtConfiguration["Jwt:Subject"]),
                      new Claim(ClaimTypes.NameIdentifier, "Riaz"),
                      new Claim(ClaimTypes.Name, "Riaz"),
                      new Claim(ClaimTypes.Email, "Riaz"),
                  };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtConfiguration["Jwt:Issuer"],
                Audience = jwtConfiguration["Jwt:Audience"],
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(listClaims),
                Expires = DateTime.Now.AddDays(50),
            };
            var handler = new Microsoft.IdentityModel.JsonWebTokens.JsonWebTokenHandler();
            var securityToken = handler.CreateToken(tokenDescriptor);
            var token = securityToken;

            return token.ToString();
        }
    }
}
