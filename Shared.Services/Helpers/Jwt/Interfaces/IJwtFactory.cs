using System.Security.Claims;
using System.Threading.Tasks;
using Shared.Core.Entities;

namespace Shared.Services.Helpers.Jwt.Interfaces
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity, User user);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}
