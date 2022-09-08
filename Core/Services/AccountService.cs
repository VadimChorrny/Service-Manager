using Core.DTOs.Google;
using Core.DTOs.UserDTO;
using Core.Entities;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomInterfaces;
using Core.Interfaces.CustomServices;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;
using System.Text;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        protected IOptions<JwtOptions> _jwtOptions;
        protected IJwtService _jwtService;
        protected UserManager<User> _userManager;
        private IRepository<RefreshToken> _refreshTokenRepository;
        protected IConfiguration _configuration;

        public AccountService(
            IOptions<JwtOptions> jwtOptions,
            IJwtService jwtService,
            UserManager<User> userManager,
            IRepository<RefreshToken> refreshTokenRepository,
            IConfiguration configuration)
        {
            _jwtOptions = jwtOptions;
            _jwtService = jwtService;
            _userManager = userManager;
            _refreshTokenRepository = refreshTokenRepository;
            _configuration = configuration;
        }

        public async Task<AuthenticationDTO> LoginAsync(string email, string password)
        {
            //await _roleManager.CreateAsync(new IdentityRole("User"));
            //await _roleManager.CreateAsync(new IdentityRole("Admin"));
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new HttpException("Invalid login or password.", System.Net.HttpStatusCode.BadRequest);
            }

            return await GenerateTokens(user);
        }

        public async Task<User> AuthenticateGoogleUserAsync(GoogleUserRequest request)
        {
            GoogleJsonWebSignature.Payload payload = await ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { _configuration["Google:ClientId"] }
            });

            return await GetOrCreateExternalLoginUser(GoogleUserRequest.PROVIDER, payload.Subject, payload.Email, payload.GivenName, payload.FamilyName);
        }
        private async Task<User> GetOrCreateExternalLoginUser(string provider, string key, string email, string firstName, string lastName)
        {
            var user = await _userManager.FindByLoginAsync(provider, key);
            if (user != null)
                return user;
            user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Email = email,
                    UserName = email,
                    Name = firstName,
                    Surname = lastName,
                    Id = key,
                };
                await _userManager.CreateAsync(user);
            }

            var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
            var result = await _userManager.AddLoginAsync(user, info);
            if (result.Succeeded)
                return user;
            return null;

        }

        public async Task<AuthenticationDTO> GenerateTokens(User user)
        {
            var claims = _jwtService.SetClaims(user);
            //var accessToken = _jwtService.CreateToken(claims);
            var refreshToken = await CreateRefreshToken(user.Id);

            var token = _jwtService.CreateToken(claims);

            var tokens = new AuthenticationDTO()
            {
                Token = token,
                RefreshToken = refreshToken.Token
            };

            return tokens;
        }

        public async Task RegisterAsync(RegisterUserDTO data)
        {
            if (data == null)
                throw new HttpException($"Error with create new account!", HttpStatusCode.NotFound);

            var user = new User()
            {
                UserName = data.Email,
                Email = data.Email,
                Name = data.Name,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                StringBuilder messageBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    messageBuilder.AppendLine(error.Description);
                }

                throw new HttpException(messageBuilder.ToString(), System.Net.HttpStatusCode.BadRequest);
            }
        }

        private async Task<RefreshToken> CreateRefreshToken(string authorId)
        {
            var refreshToken = _jwtService.CreateRefreshToken();
            var refreshTokenEntity = new RefreshToken()
            {
                Token = refreshToken,
                UserId = authorId
            };
            await _refreshTokenRepository.Insert(refreshTokenEntity);
            return refreshTokenEntity;
        }

        public Task LogoutAsync(AuthenticationDTO userTokensDTO)
        {
            throw new NotImplementedException();
        }

        public Task SentResetPasswordTokenAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthenticationDTO> RefreshTokenAsync(AuthenticationDTO authorizationDTO)
        {
            var refreshToken = await _refreshTokenRepository.Get((el) => el.Token == authorizationDTO.RefreshToken);

            var claims = _jwtService.GetClaimsFromExpiredToken(authorizationDTO.Token);
            var newAccessToken = _jwtService.CreateToken(claims);
            var newRefreshToken = _jwtService.CreateRefreshToken();

            var refreshTokenFirst = refreshToken.First();
            refreshTokenFirst.Token = newRefreshToken;

            _refreshTokenRepository.Update(refreshTokenFirst);

            var tokens = new AuthenticationDTO()
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            };
            return tokens;
        }

        public ClaimsPrincipal ValidateToken(string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
