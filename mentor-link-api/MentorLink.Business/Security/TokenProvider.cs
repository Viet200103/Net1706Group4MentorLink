using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;
using MentorLink.API.Security;
using MentorLink.Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MentorLink.Business.Security;

public class TokenProvider : ITokenProvider
{

    private readonly JwtOptions _jwtOptions;

    public TokenProvider(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }
    
    public string GenerateToken(User user, IEnumerable<string> roles)
    {

        if (_jwtOptions.SecretKey.Length < 32)
        {
            throw new SecurityException("The secret key must be at least 32 characters to avoid brute force");
        }
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var claimList = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Sub, user.UserId),
        };

        claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtOptions.ValidAudience,
            Issuer = _jwtOptions.ValidIssuer,
            Subject = new ClaimsIdentity(claimList),
            Expires = DateTime.UtcNow.AddSeconds(_jwtOptions.ExpiryInSeconds),
            SigningCredentials = credentials
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}