using Core.DTOs.EmailDTO;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly ITemplateHelper _templateHelper;
        private readonly UserManager<Entities.UserEntity.User> _userManager;
        private readonly MailJetOptions _mailJetOptions;
        private readonly IRepository<Entities.UserEntity.User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmailService(
            ITemplateHelper templateHelper,
            UserManager<Entities.UserEntity.User> userManager,
            IRepository<Entities.UserEntity.User> userRepository,
            MailJetOptions mailJetOptions, IUnitOfWork unitOfWork)
        {
            _templateHelper = templateHelper;
            _userManager = userManager;
            _userRepository = userRepository;
            _mailJetOptions = mailJetOptions;
            _unitOfWork = unitOfWork;
        }

        public async Task SendConfirmationEmailAsync(Entities.UserEntity.User user, string callbackUrl)
        {
            user.ConfirmationEmailToken = await _userManager
                .GenerateEmailConfirmationTokenAsync(user);
            user.ConfirmationEmailTokenExpirationDate = DateTimeOffset.UtcNow + TimeSpan.FromDays(1);

            await _userManager.UpdateAsync(user);

            if (!callbackUrl.Contains("swagger"))
            {
                var message = await _templateHelper
            .GetTemplateHtmlAsStringAsync<ConfirmationEmailDTO>(
            "ConfirmationEmail",
            new ConfirmationEmailDTO
            {
                Name = user.Name,
                Surname = user.Surname,
                Link = callbackUrl + "confirm-email/" +
                       user.ConfirmationEmailToken + "/"
            });

                await SendEmailAsync(user.Email, "Confirm your email", message);
            }
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new MailjetClient(_mailJetOptions.ApiKey);
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "alexander.serdyuk3@gmail.com"},
        {"Name", "Alexander"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
           email
         },
         //   {
         // "Name",
         // "Alexander"
         //}
        }
       }
      }, {
       "Subject",
       subject
      }, {
       "TextPart",
       "My first Mailjet email"
      }, {
       "HTMLPart",
       message
      }, {
       "CustomID",
       "AppGettingStartedTest"
      }
     }
    });
            MailjetResponse response = await client.PostAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpException("Fail to send email!", HttpStatusCode.BadRequest);
            }
                //var from = new EmailAddress(
                //    _appSettings.SendGridEmail,
                //    _appSettings.SendGridSenderName
                //    );
                //var to = new EmailAddress(email, email);
                //var plainTextContent = "";
                //var msg = MailHelper
                //    .CreateSingleEmail(from, to, subject, plainTextContent, message);

                //var result = await client.SendEmailAsync(msg);

                //if (!result.IsSuccessStatusCode)
                //{
                //    throw new HttpException(
                //        "Fail Send Email",
                //        HttpStatusCode.InternalServerError);
                //}
            }

            public async Task ConfirmEmailAsync(EmailConfirmationTokenRequestDTO request)
            {
                var user = (await _unitOfWork.UserRepository.Get(el => el.ConfirmationEmailToken == request.Token)).FirstOrDefault();
                //var user = await _userRepository.GetBySpecAsync(
                // new UserSpecification.GetByConfirmationToken(request.Token));

                ExceptionMethods.UserNullCheck(user);

                if (user.ConfirmationEmailTokenExpirationDate > DateTimeOffset.UtcNow)
                {
                    var confirm = await _userManager
                        .ConfirmEmailAsync(user, request.Token);

                    if (!confirm.Succeeded)
                    {
                        throw new HttpException(
                            "Fail to send email",
                            HttpStatusCode.BadRequest);
                    }

                    user.ConfirmationEmailToken = null;
                    user.ConfirmationEmailTokenExpirationDate = null;

                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    throw new HttpException(
                        "Fail to send email",
                        HttpStatusCode.BadRequest);
                }
            }
        }
    }
