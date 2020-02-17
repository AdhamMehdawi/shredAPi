using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.API.Helpers.Shared;
using Shared.Services.Helpers.Jwt;
using Shared.Services.JwtServices;
using Shared.Services.ViewModels.Jwt;
using CredentialsViewModel = Shared.Services.ViewModels.Jwt.CredentialsViewModel;

namespace Shared.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController, Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly JwtServices _jwtServices;
        public AuthController(JwtServices jwtServices, IOptions<JwtIssuerOptions> options)
        {
            _jwtServices = jwtServices;
        }
         [ServiceFilter(typeof(ValidateModelAsyncActionFilter))]
        [HttpPost("Login")]
        public async Task<ActionResult<TokenWrapper>> Login([FromBody] CredentialsViewModel credentials)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = await _jwtServices.Login(credentials);
                if (user == null)
                    return BadRequest(Resources.Language.InvalidUserNameOrPassword);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        } 
       
        //[HttpPost("RestorePassword")]
        //public async Task<object> RestorePassword([FromBody] CredentialsViewModel credentials)
        //{
        //    if (string.IsNullOrEmpty(credentials.Username))
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _db.UserRepository.GetEmpByUsername(credentials.Username);

        //    if (user == null || user.Employee.Contacts.Any(c => c.IsCurrent && c.WorkEmail == ""))
        //    {
        //        throw new Exception("user not found");
        //    }

        //    var email = user.Employee.Contacts.FirstOrDefault(c => c.IsCurrent && c.WorkEmail != "");

        //    user.ResetToken = Guid.NewGuid().ToString();
        //    user.ResetTokenExDate = DateTime.Now.AddHours(1);

        //    var link = _userService.CurrentUrl + "?token=" + user.ResetToken;

        //    var defaultMail = _db.SysMailSettingRepository.Find().FirstOrDefault();

        //    if (defaultMail == null)
        //        throw new Exception("No mail settings found");

        //    await _mailService
        //        .Send("Reset hr accoutn password", "<div dir=\"rtl\">لاستعادة كلمة المرور الخاصة بحسابك الرجاء الضغط على الرابط أدناه:" +
        //                                "<br> " +
        //                                "<br> " +
        //                                "<a href=\"" + link + "\">" + link + "</a>" +
        //                                "<br> " +
        //                                "<br> " +
        //                                "<h3>نظام ادارة الموارد البشرية <strong>نيوسوفت</strong></h3>" +
        //                                "<br> " +
        //                                "<a href=\"http://newsoft.ps\">newsoft.ps</a>" +
        //                                "</div>",
        //                   email?.WorkEmail, defaultMail.TypeId);


        //    await _db.UserRepository.UpdateAsync(user);


        //    return true;
        //}

        //[HttpPost("RestorePassword")]
        //public bool RestorePassword([FromBody] RestorePasswordViewModel passwordViewModel)
        //{
        //    var userManagement = new UserManagement(_userService, _db);
        //    try
        //    {
        //        var isReset = userManagement.RestorePassword(passwordViewModel);
        //        return isReset;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

    }
}