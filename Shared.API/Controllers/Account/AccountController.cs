using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Helpers.Shared;
using Shared.GeneralHelper.ViewModels.Users;
using Shared.Services.UsersServices;
 
namespace Shared.API.Controllers.Account
{
    [Produces("application/json"), Route("api/Accounts")]
    public class AccountController : Controller
    {
        private readonly UsersServices _usersServices;

        public AccountController(UsersServices usersServices)
        {
            _usersServices = usersServices;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var userObj = await _usersServices.GetAll();
            return new SharedResponseResult<List<DisplayUserViewModel>>(userObj);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var userObj = await _usersServices.GetUser(id);
            return new SharedResponseResult<DisplayUserViewModel>(userObj);
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody]AppUserViewModel userData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userObj = await _usersServices.CreateNewUser(userData);
            return new SharedResponseResult<DisplayUserViewModel>(userObj, "The user has been created successfully");
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
                //    UpdatedBy = _usersInfo.Id
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
            //UserAuthService userManagement = new UserAuthService(_usersInfo, _db);

            try
            {
                //var isReset = userManagement.ResetPassword(passwordViewModel);
                //if (isReset)
                //{
                //    User user = _db.UserRepository.Find(usr => usr.Id == _usersInfo.Id).FirstOrDefault();
                //    //var userVM = _mapper.Map<AppUserViewModel>(user);
                //    ClaimsIdentity identity = await GetClaimsIdentity(user);

                //    if (identity == null)
                //    {
                //        return BadRequest(ErrorResponse.AddErrorToModelState("login_failure", Resources.Language.InvalidUserNameOrPassword,
                //            ModelState));
                //    }

                //    var response = new
                //    {
                //        id = _usersInfo.Id,
                //        token = await _jwtFactory.GenerateEncodedToken(user.Username, identity, user),
                //        expires_in = (int)_jwtOptions.ValidFor.TotalSeconds
                //    };

                //    return response;
                //}
                return true;
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

    }
}