using Microsoft.AspNetCore.Identity;

namespace Airline.API.Data.Repositories.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
