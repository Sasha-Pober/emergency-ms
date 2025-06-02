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

    public JwtTokenService(IConfiguration configuration, IRsaKeyProvider rsaKeyProvider)
    {
        _configuration = configuration;
        _rsaKeyProvider = rsaKeyProvider;
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
            expires: DateTime.UtcNow.AddMinutes(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
