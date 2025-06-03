using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Services.Implementations.JWT;

internal class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly IRsaKeyProvider _rsaKeyProvider;
    private readonly int _expiryTime;

    public JwtTokenService(IConfiguration configuration, IRsaKeyProvider rsaKeyProvider)
    {
        _configuration = configuration;
        _rsaKeyProvider = rsaKeyProvider;

        _expiryTime = Environment.GetEnvironmentVariable("JWT_EXPIRYTIME") != null
            ? int.Parse(Environment.GetEnvironmentVariable("JWT_EXPIRYTIME"))
            : 3600; // Default to 1 hour if not set
    }

    public string CreateAccessToken(ApplicationUser user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName ?? ""),
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var rsaKey = _rsaKeyProvider.GetPrivateKey();

        var credentials = new SigningCredentials(new RsaSecurityKey(rsaKey), SecurityAlgorithms.RsaSha256);

        var token = new JwtSecurityToken(
            issuer: "API",
            audience: "emergerncyMS",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_expiryTime),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
