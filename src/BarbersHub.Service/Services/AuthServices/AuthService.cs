using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BarbersHub.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using BarbersHub.Service.Interfaces.AuthServices;
        
namespace BarbersHub.Service.Services.AuthServices;

public class AuthService : IAuthService
{
    private readonly IConfigurationSection _configuration;

    public AuthService(IConfiguration configuration)
    {
        this._configuration = configuration.GetSection("Jwt");
    }

    public string GenerateToken(User user)
    {
        var claims = new[]
       {

            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName+ " " + user.LastName),
            new Claim("PhoneNumber", user.PhoneNumber),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(_configuration["Issuer"], _configuration["Audience"], claims,
            expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Lifetime"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
