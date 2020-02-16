using System.Threading.Tasks;
using Shared.Core.Entities;

namespace Shared.Core.Interfaces.IUsers
{
    public interface IUsersRepository : IRepo<User>
    {
        Task<User> CheckLogin(string username, string password);
        Task<User> CheckLogin(string username);
        Task<User> GetEmpByUsername(string credentialsUsername);
    }
}