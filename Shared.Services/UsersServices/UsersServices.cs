
using System;
using System.Collections.Generic;
using Shared.Core.Entities;
using Shared.Core.HelperModels;
using Shared.Core.Interfaces;
using Shared.Core.Interfaces.IUsers;
using System.Threading.Tasks;
using AutoMapper;
using Shared.GeneralHelper.Helpers;
using Shared.GeneralHelper.ViewModels.Users;

namespace Shared.Services.UsersServices
{

    public class UsersServices
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly UserService _usersService;
        private readonly IUnitOfWork _unitOfWork;
        public UsersServices(IUsersRepository usersRepository, IMapper mapper, UserService usersService, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _usersService = usersService;
            _unitOfWork = unitOfWork;
        }
        public async Task<DisplayUserViewModel> GetUser(int id)
        {
            var userData = await _usersRepository.GetAsync(c => c.Id == id);
            var userResult = _mapper.Map<DisplayUserViewModel>(userData);
            return userResult;
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
                if (user == null)
                    return null;
            }
            if (user.PassExpireDate.HasValue && user.PassExpireDate < DateTime.Now)
                user = null;
            return user;
        }

        public async Task<List<DisplayUserViewModel>> GetAll()
        {
            var result = await _usersRepository.GetAllAsync();
            return _mapper.Map<List<DisplayUserViewModel>>(result);
        }

        public async Task<User> GetEmpByUsername(string credentialsUsername)
        {
            var user = await _usersRepository.GetEmpByUsername(credentialsUsername);
            if (user.PassExpireDate.HasValue && user.PassExpireDate < DateTime.Now)
                user = null;
            return user;
        }

        public async Task<DisplayUserViewModel> CreateNewUser(AppUserViewModel userObj)
        {
            var credentials = _mapper.Map<User>(userObj);
            credentials.Password = Encryption.Encrypt(userObj.Password, true);
            credentials.NeedResetPassword = true;
            credentials.PassExpireDate = DateTime.Now.AddDays(20);
            credentials.ResetTokenExDate = DateTime.Now.AddDays(20);
            await _usersRepository.AddAsync(credentials);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<DisplayUserViewModel>(credentials);
        }
    }
}
