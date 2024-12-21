using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Models;
using RestaurantReservation.API.Services.Interfaces;

namespace MinimalApiWithJWT.Services
{
    public class JWTTokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _config;
        private readonly string _issuer;
        private readonly string _key;
        private readonly string _audience;

        public JWTTokenGenerator(IConfiguration config)
        {
            _config = config;
            _issuer = _config["JWTToken:Issuer"]?.Trim() ?? "doge";
            _audience = _config["JWTToken:Audience"]?.Trim() ?? "yoinker";
            _key = _config["JWTToken:Key"]?.Trim() ?? throw new ArgumentNullException("JWTToken:Key");
        }

    public string GenerateToken(UserWithoutPasswordDTO user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
        
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            try {
                tokenHandler.ValidateToken(token, new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidIssuer = _issuer,
                    ValidateAudience = true,
                    ValidAudience = _audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                }, out SecurityToken validateToken);

                return validateToken != null;
            } catch
            {
                return false;
            }
        } 
    }
}