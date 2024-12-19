using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UltraGroupHotels.Application.Users.Common.Authorization;
using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Infrastructure.Authorization;

public class JwtService : IJwtService
{
    private readonly JwtOptions _jwtOptions;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public JwtService(IOptions<JwtOptions> jwtOptions, IHttpContextAccessor httpContextAccessor)
    {
        _jwtOptions = jwtOptions.Value;
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    public string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role.Value)

            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenExpiration),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience, 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };


        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public TokenInformation GetTokenInformation()
    {

        HttpContext httpContext = _httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(_httpContextAccessor.HttpContext));
        IHeaderDictionary headers = httpContext.Request.Headers;

        string token = headers.Authorization.ToString().Split(' ').Last() ?? string.Empty;
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException("Token is missing");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var JwtSecurityToken = tokenHandler.ReadJwtToken(token);

        Guid id = Guid.Parse(JwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value);
        string email = JwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Email).Value;
        string fullName = JwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Name).Value;
        string role = JwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;

        return new TokenInformation(id, fullName, email, role);
    }
}
