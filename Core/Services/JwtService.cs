using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces.CustomServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Core.Entities.UserEntity;

namespace Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public JwtService(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _jwtOptions = jwtOptions;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //public string CreateRefreshToken()
        //{
        //    var randomNumbers = new byte[32];
        //    using var rng = RandomNumberGenerator.Create();
        //    rng.GetBytes(randomNumbers);
        //    return Convert.ToBase64String(randomNumbers);
        //}

        public string CreateToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.Value.LifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> GetClaimsFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Value.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key)),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken;

            tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new HttpException("Invalid Token!", System.Net.HttpStatusCode.BadRequest);

            return jwtSecurityToken.Claims;
        }

        public IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id),
                new Claim("Email", user.Email),
                new Claim("Name", user.UserName),

            };
            var userRoles = _userManager.GetRolesAsync(user).Result;
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = _roleManager.FindByNameAsync(userRole).Result;
                if (role != null)
                {
                    var roleClaims = _roleManager.GetClaimsAsync(role).Result;
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            //user.Roles
            //var roles = userManager.GetRolesAsync(user).Result;
            //foreach (var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}
            return claims;
        }
        public string CreateRefreshToken()
        {
            var randomBytes = new byte[32];
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();

            rngCryptoServiceProvider.GetBytes(randomBytes);

            var refreshToken = Convert.ToBase64String(randomBytes);

            return refreshToken;
        }
    }
}
