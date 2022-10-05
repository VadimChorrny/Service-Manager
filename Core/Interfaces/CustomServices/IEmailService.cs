using Core.DTOs.EmailDTO;
using Core.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs.UserDTO;

namespace Core.Interfaces.CustomServices
{
    public interface IEmailService
    {
        Task SendConfirmationEmailAsync(User user, string callbackUrl);
        Task SendEmailAsync(string email, string subject, string message);
        Task ConfirmEmailAsync(EmailConfirmationTokenRequestDTO request);
        Task SendResetPasswordEmailAsync(ResetPasswordDTO forgotPasswordModel, string callbackUrl);
    }
}
