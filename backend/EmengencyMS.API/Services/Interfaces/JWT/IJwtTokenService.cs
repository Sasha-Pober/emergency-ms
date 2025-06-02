using Domain.Entities;

namespace Services.Interfaces.JWT;

public interface IJwtTokenService
{
    string CreateAccessToken(ApplicationUser user, IList<string> roles);
}