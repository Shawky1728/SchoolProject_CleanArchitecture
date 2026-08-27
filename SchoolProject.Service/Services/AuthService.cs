using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SchoolProject.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtOptions _jwtOptions;
        public AuthService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public (string token, int ExpiresIn) GenerateTokenAsync(User user, IEnumerable<string> roles)
        {
            Claim[] claims = [

           new Claim (JwtRegisteredClaimNames.Sub, user.Id),
             new Claim(JwtRegisteredClaimNames.Email, user.Email),
             new Claim(JwtRegisteredClaimNames.GivenName, user.NameEn),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
              new Claim(nameof(roles), JsonSerializer.Serialize(roles),JsonClaimValueTypes.JsonArray)
           ];

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            int expiresIn = _jwtOptions.ExpiresIn;

            var expirationDate = DateTime.UtcNow.AddMinutes(expiresIn);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: signingCredentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenString = tokenHandler.WriteToken(token);

            return (tokenString, expiresIn);

        }

        public string? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = symetricSecurityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken securityToken);

                var jwtToken = (JwtSecurityToken)securityToken;

                var userId = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;

                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}

