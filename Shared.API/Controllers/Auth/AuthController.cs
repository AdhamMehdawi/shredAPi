 using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
 using Shared.API.Helpers.Shared;
using Shared.GeneralHelper.ViewModels.Jwt;
using Shared.Services.JwtServices;
 
namespace Shared.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController, Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly JwtServices _jwtServices;
        public AuthController(JwtServices jwtServices)
        {
            _jwtServices = jwtServices;
        }
        [ServiceFilter(typeof(ValidateModelAsyncActionFilter))]
        [HttpPost("Login")]
        public async Task<ActionResult<TokenWrapper>> Login([FromBody] CredentialsViewModel credentials)
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

    }
}