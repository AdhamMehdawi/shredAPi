using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.Entities;
using Shared.Services.Helpers.Jwt;
using Shared.Services.Helpers.Jwt.Interfaces;
using Shared.Services.ViewModels.Jwt;

namespace Shared.Services.JwtServices
{
    public class JwtServices
    {
        private readonly UsersServices.UsersServices _usersServices;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private IOptions<JwtIssuerOptions> _options;
        public JwtServices( IJwtFactory jwtFactory, JwtIssuerOptions jwtOptions, UsersServices.UsersServices usersServices, IOptions<JwtIssuerOptions> options)
        {
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions;
            _usersServices = usersServices;
            _options = options;
        }

 

        public async Task<TokenWrapper> Login(CredentialsViewModel credentials)
        {
            var user = await _usersServices.GetUser(credentials.Username, credentials.Password);
            var identity = await GetClaimsIdentity(user);
            if (identity == null)
                return null;
            var response = new TokenWrapper
            {
                Id = identity.Claims.Single(c => c.Type == "id").Value,
                Token = await _jwtFactory.GenerateEncodedToken(credentials.Username, identity, user),
                ExpiresIn = _jwtOptions.ValidFor.TotalSeconds
            };
            return response;
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(User user)
        {
            if (!(user is null))
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(user.Username, user.Id.ToString()));
            return await Task.FromResult<ClaimsIdentity>(null);
        }

        public   bool LifetimeValidator(DateTime? notBefore, DateTime? expires,
            SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires)
                {
                    return true;
                }
            }
            return false;
        }

        public   User ValidateToken(string securityTokenWrapper)
        {
            var handler = new JwtSecurityTokenHandler();
            if (!(handler.ReadToken(securityTokenWrapper) is JwtSecurityToken decodedToken)) return null;
       
            var validationParameters = new TokenValidationParameters
            {
                ValidAudience = _options.Value.Audience,
                ValidIssuer = _options.Value.Issuer,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                LifetimeValidator = LifetimeValidator,
                IssuerSigningKey = _options.Value.SigningCredentials.Key,
                ValidateIssuer = true,
                ValidateAudience = true
            };
            //extract and assign the user of the jwt
            var claimsIdentity = handler.ValidateToken(securityTokenWrapper, validationParameters, out _);

            int.TryParse(decodedToken.Claims.FirstOrDefault(claim => claim.Type == "employeeId")?.Value,
                out var employeeId);
            var user = new User
            {
                Username = claimsIdentity.Claims
                    .FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.GivenName)?.Value,
                Email = claimsIdentity.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value,
                EmployeeId = employeeId,
                IsSuperAdmin = bool.Parse(claimsIdentity.Claims.FirstOrDefault(claim => claim.Type == "isSuperAdmin")
                    ?.Value),
                NeedResetPassword = bool.Parse(claimsIdentity.Claims
                    .FirstOrDefault(claim => claim.Type == "needResetPassword")?.Value)
            };
            return user;
        }
    }

}
