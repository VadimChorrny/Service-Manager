using Core.DTOs.Google;
using Core.DTOs.UserDTO;
using Core.Entities;
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
using AutoMapper;
using Mailjet.Client.Resources;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using User = Core.Entities.UserEntity.User;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        protected IOptions<JwtOptions> JwtOptions;
        protected IJwtService JwtService;
        protected UserManager<User> _userManager;
        private IRepository<RefreshToken> _refreshTokenRepository;
        protected IConfiguration Configuration;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        public AccountService(
            IOptions<JwtOptions> jwtOptions,
            IJwtService jwtService,
            UserManager<User> userManager,
            IRepository<RefreshToken> refreshTokenRepository,
            IConfiguration configuration, IEmailService emailService, IMapper mapper)
        {
            JwtOptions = jwtOptions;
            JwtService = jwtService;
            _userManager = userManager;
            _refreshTokenRepository = refreshTokenRepository;
            Configuration = configuration;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetUserProfile(string userName)
        {
            var user = await _userManager.FindByIdAsync(userName);
            if (user == null)
            {
                throw new HttpException("User isn`t exists", HttpStatusCode.BadRequest);
            }
            return _mapper.Map<UserDTO>(user);
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

        public async Task ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var user = await _userManager.FindByIdAsync(changePasswordDTO.UserId);
            await _userManager.ResetPasswordAsync(user, changePasswordDTO.Token, changePasswordDTO.Password);
        }
        public async Task<User> AuthenticateGoogleUserAsync(GoogleUserRequest request)
        {
            GoogleJsonWebSignature.Payload payload = await ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { Configuration["Google:ClientId"] }
            });

            return await GetOrCreateExternalLoginUser(GoogleUserRequest.Provider, payload.Subject, payload.Email, payload.GivenName, payload.FamilyName);
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
            var claims = JwtService.SetClaims(user);
            //var accessToken = _jwtService.CreateToken(claims);
            var refreshToken = await CreateRefreshToken(user.Id);

            var token = JwtService.CreateToken(claims);

            var tokens = new AuthenticationDTO()
            {
                Token = token,
                RefreshToken = refreshToken.Token
            };

            return tokens;
        }
        public async Task RegisterAsync(RegisterUserDTO data, string callbackUrl)
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
            await _emailService.SendConfirmationEmailAsync(user, callbackUrl);
        }

        private async Task<RefreshToken> CreateRefreshToken(string authorId)
        {
            var refreshToken = JwtService.CreateRefreshToken();
            var refreshTokenEntity = new RefreshToken()
            {
                Token = refreshToken,
                UserId = authorId
            };
            await _refreshTokenRepository.Insert(refreshTokenEntity);
            await _refreshTokenRepository.SaveChangesAsync();
            return refreshTokenEntity;
        }

        public async Task LogoutAsync(UserLogoutDTO userTokensDTO)
        {
            var refreshToken = (await _refreshTokenRepository.GetFirstOrDefaultAsync(r => r.Token == userTokensDTO.RefreshToken));
            if (refreshToken == null)
            {
                throw new HttpException("Refresh token is null", HttpStatusCode.Forbidden);
            }
            await _refreshTokenRepository.Delete(refreshToken.Id);
            await _refreshTokenRepository.SaveChangesAsync();
        }

        //public async Task SentResetPasswordTokenAsync(ResetPasswordDTO forgotPasswordModel, string callbackUrl)
        //{
        //    var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
        //    if (user == null)
        //        throw new HttpException("Not found user", HttpStatusCode.BadRequest);
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //    var frontEndURL = _configuration.GetValue<string>("FrontEndURL");

        //    //var callbackUrl =
        //    //    $"{frontEndURL}/resetpassword?userId={user.Id}&" +
        //    //    $"code={WebUtility.UrlEncode(token)}";

        //    //Url.Action(nameof(ResetPassword), "AccountController", new { token, email = user.Email }, Request.Scheme);
        //    //var message = new Message(new string[] { forgotPasswordModel.Email }, "Reset password token",
        //    //    $"Please reset password by clicking here: " +
        //    //    $"<a href='{callbackUrl}'>Відновити</a>");
        //    _emailService.SendEmail(message);

            
        //    //var user = await _userManager.FindByIdAsync(model.UserId);
        //    //var res = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        //}

        public async Task<AuthenticationDTO> RefreshTokenAsync(AuthenticationDTO authorizationDTO)
        {
            var refreshToken = await _refreshTokenRepository.GetFirstOrDefaultAsync((el) => el.Token == authorizationDTO.RefreshToken);

            var claims = JwtService.GetClaimsFromExpiredToken(authorizationDTO.Token);
            var newAccessToken = JwtService.CreateToken(claims);
            var newRefreshToken = JwtService.CreateRefreshToken();

            //var refreshTokenFirst = refreshToken.First();
            refreshToken.Token = newRefreshToken;

            _refreshTokenRepository.Update(refreshToken);
            await _refreshTokenRepository.SaveChangesAsync();
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
