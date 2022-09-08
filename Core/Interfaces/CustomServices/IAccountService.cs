using System.Security.Claims;
using Core.DTOs.Google;
using Core.DTOs.UserDTO;
using Core.Entities.UserEntity;

namespace Core.Interfaces.CustomInterfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterUserDTO data);
        Task<AuthenticationDTO> LoginAsync(string email, string password);
        Task<AuthenticationDTO> GenerateTokens(User user);
        Task LogoutAsync(AuthenticationDTO userTokensDTO);
        Task SentResetPasswordTokenAsync(string userEmail);
        Task<User> AuthenticateGoogleUserAsync(GoogleUserRequest request);
        Task<AuthenticationDTO> RefreshTokenAsync(AuthenticationDTO authorizationDTO);
        ClaimsPrincipal ValidateToken(string jwtToken);
        //Task ResetPasswordAsync(AuthorChangePasswordDTO userChangePasswordDTO);
    }
}
