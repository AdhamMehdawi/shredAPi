using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Shared.GeneralHelper.ViewModels.Users;
 
namespace Shared.API.Helpers.Auth
{
    public class AuthenticationManager
    {
        private const string SecKey = "dd%88*377f6d&f£$$£$FdddFF33fssDG^!3";
        public DateTime NotBefore { get; set; } = DateTime.Now;
        public DateTime IssuedAt { get; set; } = DateTime.Now;
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromHours(24);
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public ClaimsIdentity GetTokenClaim(UserInfoModel modelData)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(

            new GenericIdentity(modelData.UserName, "Token"), new[]
            {
                new Claim("userId", modelData.UserId.ToString()),
                new Claim("fullName", modelData.DisplayName),
                new Claim("role", "ApiAccess"),
                new Claim("acceptToken", modelData.AcceptToken),
                new Claim("id", modelData.Id.ToString()),
                new Claim("admin", modelData.IsAdmin.ToString()),
                new Claim("manager", modelData.IsManager.ToString())
            });

            return claimsIdentity;
        }

        public string CreateToken(UserInfoModel modelData)
        {

            //set the time when it expires
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = GetTokenClaim(modelData);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(SecKey));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            JwtSecurityToken token = tokenHandler.CreateJwtSecurityToken(
                issuer: "http://localhost:2206",
                audience: "http://localhost:4200",
                subject: claimsIdentity,
                notBefore: IssuedAt,
                expires: Expiration,
                signingCredentials: signingCredentials
            );

            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
