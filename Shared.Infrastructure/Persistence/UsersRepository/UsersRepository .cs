using System;
 using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 using Shared.Core.Entities;
using Shared.Core.HelperModels;
using Shared.Core.Interfaces.IUsers;
using Shared.Infrastructure.Data;

namespace Shared.Infrastructure.Persistence.UsersRepository
{
    public class UsersRepository : Repo<User>,IUsersRepository
    {
        private readonly SharedContext _db;

        public UsersRepository(SharedContext context, UserService userService)
            : base(context, userService)
        {
            _db = context;
        }


        public async Task<User> CheckLogin(string username, string password)
        {
            return await _db.Users.Include(x => x.Employee)
                .IgnoreQueryFilters()
               .FirstOrDefaultAsync(c => c.Username == username && c.Password == password);
        }
        public async Task<User> CheckLogin(string username)
        {
            return await _db.Users.Include(x => x.Employee)
               .FirstOrDefaultAsync(c => c.Username == username);
        }


        public async Task<User> GetEmpByUsername(string credentialsUsername)
        {
            var user = await _db.Users
                .Include(x => x.Employee)
                 .FirstOrDefaultAsync(c => c.Username == credentialsUsername);
            if (user.PassExpireDate.HasValue && user.PassExpireDate < DateTime.Now)
                user = null;
            return user;
        }
    }
}