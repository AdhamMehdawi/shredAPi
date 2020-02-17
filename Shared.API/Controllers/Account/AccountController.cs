using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.Core.Interfaces;
using Shared.Services.Helpers.Jwt;
using Shared.Services.Helpers.Jwt.Interfaces;
using Shared.Services.ViewModels.ServicesViewModel;
using Shared.API.Helpers.Auth;
using Shared.Core.Entities;
using Shared.Services.UsersServices;
using Shared.Services.ViewModels.Users;

namespace Shared.API.Controllers.Account
{
    [Produces("application/json"), Route("api/Accounts")]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _db;

        private readonly AuthenticationManager _authManager;

        private readonly IHttpContextAccessor _accessor;
        private readonly UserService _usersService;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;


        public AccountController(
            IMapper mapper,
            IUnitOfWork db,
            IHttpContextAccessor accessor,
            IJwtFactory jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions,
            UserService usersService
            )
        {
            _mapper = mapper;
            _db = db;
            _authManager = new AuthenticationManager();
            _accessor = accessor;
            _usersService = usersService;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpGet]
        public List<AppUserViewModel> Get()
        {
            //try
            //{
            //    IEnumerable<AppUser> list = _db.UserRepository.Find(null, null, "Employee");
            //    var listVM = _mapper.Map<List<AppUserViewModel>>(list);
            //    return listVM;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }

        [HttpGet("{id}")]
        public async Task<AppUserViewModel> Get(int id)
        {
            //try
            //{
            //    AppUser item = await _db.UserRepository.GetAsyncById(id);
            //    return _mapper.Map<AppUserViewModel>(item);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AppUserViewModel credentialsVM)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                //var credentials = _mapper.Map<AppUser>(credentialsVM);
                //Models.Employees.Employee employee = _db.EmployeeRepository.Find(x => x.Id == credentials.EmployeeId).FirstOrDefault();

                //User user = new User
                //{
                //    Email = credentials.Email,
                //    EmployeeId = credentials.EmployeeId,
                //    FullName = credentials.FullName,
                //    Password = Encryption.Encrypt(employee.EmpNo.ToString(), true),
                //    Username = employee.EmpNo.ToString(),
                //    NeedResetPassword = credentials.NeedResetPassword,
                //    PassExpireDate = credentials.PassExpireDate,
                //    IsSuperAdmin = credentials.IsSuperAdmin,
                //    UpdateDate = DateTime.Now,
                //    UpdatedBy = _usersService.Id,
                //    CreateDate = DateTime.Now,
                //    CreatedBy = _usersService.Id
                //};

                //await _db.UserRepository.AddAsync(user);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]AppUserViewModel appUserVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                //var appUser = _mapper.Map<AppUser>(appUserVM);
                //appUser.Id = id;

                //var originalUser = _db.UserRepository.Find(x => x.Id == id).FirstOrDefault();

                //User user = new User
                //{
                //    Id = appUser.Id,
                //    Email = appUser.Email,
                //    EmployeeId = appUser.EmployeeId,
                //    FullName = appUser.FullName,
                //    Username = appUser.Username,
                //    Password = originalUser.Password,
                //    NeedResetPassword = appUser.NeedResetPassword,
                //    PassExpireDate = appUser.PassExpireDate,
                //    IsSuperAdmin = appUser.IsSuperAdmin,
                //    UpdateDate = DateTime.Now,
                //    UpdatedBy = _usersService.Id
                //};

                //await _db.UserRepository.UpdateAsync(user);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("UpdatePassword")]
        public async Task<object> UpdatePassword([FromBody]ResetPasswordViewModel passwordViewModel)
        {
            UserAuthService userManagement = new UserAuthService(_usersService, _db);

            try
            {
                var isReset = userManagement.ResetPassword(passwordViewModel);
                //if (isReset)
                //{
                //    User user = _db.UserRepository.Find(usr => usr.Id == _usersService.Id).FirstOrDefault();
                //    //var userVM = _mapper.Map<AppUserViewModel>(user);
                //    ClaimsIdentity identity = await GetClaimsIdentity(user);

                //    if (identity == null)
                //    {
                //        return BadRequest(ErrorResponse.AddErrorToModelState("login_failure", Resources.Language.InvalidUserNameOrPassword,
                //            ModelState));
                //    }

                //    var response = new
                //    {
                //        id = _usersService.Id,
                //        token = await _jwtFactory.GenerateEncodedToken(user.Username, identity, user),
                //        expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
                //    };

                //    return response;
                //}
                return isReset;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("ResetPassword")]
        public async Task<bool> ResetPassword([FromBody] int userId)
        {
            try
            {
                //User user = (await _db.UserRepository.GetAsyncAsNoTracking(x => x.Id == userId)).FirstOrDefault();
                //if (user == null) return false;

                //user.Password = Encryption.Encrypt(user.Username + "", true);

                //user.NeedResetPassword = true;
                //User update = _db.UserRepository.Update(user);

                return true;
            }
            catch
            {
                return false;
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               // _db.UserRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(User user)
        {
            if (!(user is null))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(user.Username, user.Id.ToString()));
            }
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}