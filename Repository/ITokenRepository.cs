using Microsoft.AspNetCore.Identity;

namespace NzApp.Repository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
