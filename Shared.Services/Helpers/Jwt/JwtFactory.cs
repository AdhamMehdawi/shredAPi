using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shared.Core.Entities;
using Shared.Services.Helpers.HelperClasses;
using Shared.Services.Helpers.Jwt.Interfaces;

namespace Shared.Services.Helpers.Jwt
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
                new Claim("email", user.Email ?? ""),
                new Claim("userId", user.Username),
                new Claim("employeeId", user.EmployeeId.ToString()),
                new Claim("needResetPassword", user.NeedResetPassword.ToString()),
                new Claim("isSuperAdmin", user.IsSuperAdmin.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(),
                    ClaimValueTypes.Integer64),
                identity.FindFirst("role"),
                identity.FindFirst("id")
            };

            if (user.Employee?.FullName != null)
            {
                var fullNameAr =
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.FirstName, "ar")} " +
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.SecondName, "ar")} " +
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.ThirdName, "ar")} " +
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.LastName, "ar")}";

                var fullNameEn =
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.FirstName, "en-US")} " +
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.SecondName, "en-US")} " +
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.ThirdName, "en-US")} " +
                $"{new JsonParser(null, null).ConvertJsonToTextByLocale(user.Employee.LastName, "en-US")}";

                claims.Add(new Claim("fullnameAr", fullNameAr));
                claims.Add(new Claim("fullnameEn", fullNameEn));

            }
            else
            {
                claims.Add(new Claim("fullnameAr", new JsonParser(null, null).ConvertJsonToTextByLocale(user.FullName, "ar")));
                claims.Add(new Claim("fullnameEn", new JsonParser(null, null).ConvertJsonToTextByLocale(user.FullName, "en-US")));
            }

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                issuer: "http://localhost:58488",
                audience: "http://localhost:4200",
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(120)),
                signingCredentials: _jwtOptions.SigningCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public ClaimsIdentity GenerateClaimsIdentity(string userName, string id)
        {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim("id", id),
                new Claim("role", "api_access")
            });
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round(
            (date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));

            if (options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
        }
    }
}
