using Core.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.CustomServices
{
    public interface IJwtService
    {
        IEnumerable<Claim> SetClaims(User user);
        string CreateToken(IEnumerable<Claim> claims);
        string CreateRefreshToken();
        IEnumerable<Claim> GetClaimsFromExpiredToken(string token);
        // ===== Need Add Posibility For Authentication using Google Auth
        // Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(UserExternalAuthDTO authDTO);
    }
}
