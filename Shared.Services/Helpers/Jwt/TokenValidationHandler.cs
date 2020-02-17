using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.Entities;


namespace Shared.Services.Helpers.Jwt
{
    public class TokenValidationHandler : ISecurityTokenValidator
    {
        public bool CanValidateToken => throw new NotImplementedException();
        public int MaximumTokenSizeInBytes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private readonly SigningCredentials _signingCredentials;
        public TokenValidationHandler(SigningCredentials signingCredentials)
        {
            _signingCredentials= signingCredentials;
        }
        public bool CanReadToken(string securityToken) => true;
        public User ValidateToken(string securityTokenWrapper)
        {
            var handler = new JwtSecurityTokenHandler();
            if (!(handler.ReadToken(securityTokenWrapper) is JwtSecurityToken decodedToken)) return null;

            var validationParameters = new TokenValidationParameters
            {
                ValidIssuer= "http://localhost:58488",
                ValidAudience= "http://localhost:4200",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                LifetimeValidator = LifetimeValidator,
                IssuerSigningKey = _signingCredentials.Key,
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
                    .FirstOrDefault(claim => claim.Type == "userId")?.Value,
                Email = claimsIdentity.Claims.FirstOrDefault(claim => claim.Type == "email")?.Value,
                EmployeeId = employeeId,
                IsSuperAdmin = bool.Parse(claimsIdentity.Claims.FirstOrDefault(claim => claim.Type == "isSuperAdmin")
                                              ?.Value ?? throw new InvalidOperationException()),
                NeedResetPassword = bool.Parse(claimsIdentity.Claims
                                                   .FirstOrDefault(claim => claim.Type == "needResetPassword")?.Value ?? throw new InvalidOperationException())
            };
            return user;
        }
        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            validatedToken = null;
            var user =  ValidateToken(securityToken);
            if (user == null)
                throw new SecurityTokenException("invalid");
            validationParameters.ValidateTokenReplay = true;
            //create your identity by generating its claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, ""),
                 new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
                new Claim("userId", user.Username),
                new Claim("email", user.Email ?? ""),
                new Claim("employeeId", user.EmployeeId.ToString()),
                new Claim("needResetPassword", user.NeedResetPassword.ToString()),
            };
            return new ClaimsPrincipal(new ClaimsIdentity(new GenericIdentity(user.Username, "Token"), claims));
        }
        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires == null) return false;
            return DateTime.UtcNow < expires;
        }
    }
}
