using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.API.Helpers.Shared;
using Shared.Core.Entities;
using Shared.Services.Helpers.Jwt;
using Shared.Services.JwtServices;
using Shared.Services.ViewModels.Jwt;

namespace Shared.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController, Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly JwtServices _jwtServices;
        //IOptions<JwtIssuerOptions> _options;
        private readonly TokenValidationHandler _tokenValidationHandler;
        public AuthController(JwtServices jwtServices, IOptions<JwtIssuerOptions> options)
        {
            _jwtServices = jwtServices;
            //_options = options;
            _tokenValidationHandler = new TokenValidationHandler(options.Value.SigningCredentials);
        }
         [ServiceFilter(typeof(ValidateModelAsyncActionFilter))]
        [HttpPost("Login")]
        public async Task<ActionResult<TokenWrapper>> Login([FromBody] CredentialsViewModel credentials)
        {
            try
            {
                var user = await _jwtServices.Login(credentials);
                if (user == null)
                    return BadRequest("Invalid username or password");
                return user;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
           
        }

        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("IsAuthenticated")]
        public User IsAuthenticated([FromBody]SecurityTokenWrapper securityTokenWrapper)
        {
            return _tokenValidationHandler.ValidateToken(securityTokenWrapper.SecurityToken);
        }

        //[HttpPost("RestorePassword")]
        //public async Task RestorePassword([FromBody] CredentialsViewModel credentials)
        //{
        //    if (string.IsNullOrEmpty(credentials.Username))
        //        throw new HttpException(HttpStatusCode.BadRequest, "Username was not sent correctly", ModelState);

        //    AppUser user = await _db.UserRepository.GetEmpByUsername(credentials.Username);

        //    if (user == null || user.Employee.Contacts.Any(c => c.IsCurrent && c.WorkEmail == ""))
        //        throw new HttpException(HttpStatusCode.BadRequest, "User was not found");

        //    var email = user.Employee.Contacts.FirstOrDefault(c => c.IsCurrent && c.WorkEmail != "");

        //    user.ResetToken = Guid.NewGuid().ToString();
        //    user.ResetTokenExDate = DateTime.Now.AddHours(1);
 
        //    string link = _userService.CurrentUrl + "?token=" + user.ResetToken;

        //    Models.SysSettings.SysMailSetting defaultMail = _db.SysMailSettingRepository.Find().FirstOrDefault();

        //    if (defaultMail == null)
        //        throw new Exception("No mail settings was configured");

        //    await _mailService
        //        .Send("reset password", "<div dir=\"rtl\">لاستعادة كلمة المرور الخاصة بحسابك الرجاء الضغط على الرابط أدناه:" +
        //                                    "<br> " +
        //                                    "<br> " +
        //                                    "<a href=\"" + link + "\">" + link + "</a>" +
        //                                    "<br> " +
        //                                    "<br> " +
        //                                    "<h3>نظام ادارة الموارد البشرية <strong>نيوسوفت</strong></h3>" +
        //                                    "<br> " +
        //                                    "<a href=\"http://newsoft.ps\">newsoft.ps</a>" +
        //                                "</div>",
        //            email?.WorkEmail, defaultMail.TypeId);

        //    await _db.UserRepository.UpdateAsync(user);
        //}

        //[HttpPost("CompleteRestorePassword")]
        //public bool RestorePassword([FromBody] RestorePasswordViewModel passwordViewModel)
        //{
        //    UserManagement userManagement = new UserManagement(_userService, _db);
        //    try
        //    {
        //        bool isReset = userManagement.RestorePassword(passwordViewModel);
        //        return isReset;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

      
    }
}