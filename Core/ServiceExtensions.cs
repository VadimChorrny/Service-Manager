using AutoMapper;
using Core.DTOs.Country;
using Core.DTOs.Language;
using Core.DTOs.PhoneCode;
using Core.DTOs.Service;
using Core.DTOs.Subscriptions;
using Core.DTOs.Transactions;
using Core.DTOs.Transactions.Json;
using Core.DTOs.UserDTO;
using Core.Entities.CountryEntity;
using Core.Entities.LanguageEntity;
using Core.Entities.SubscriptionEntity;
using Core.Entities.TransactionEntity;
using Core.Entities.UserEntity;
using Core.Helpers;
using Core.Interfaces;
using Core.Interfaces.CustomInterfaces;
using Core.Interfaces.CustomServices;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAccountService, AccountService>(); // remove before migrations
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUserBankService, UserBankService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITemplateHelper, TemplateHelper>();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.CreateMap<User, UserDTO>().ReverseMap();
                mc.CreateMap<RegisterUserDTO, User>().ReverseMap();
                mc.CreateMap<TransactionDTO, Transaction>().ReverseMap(); //ForMember(dest => dest.);
                mc.CreateMap<Subscription, SubscriptionResponseDTO>()
                    //.ForMember(dest => dest.BillingCycle, act => act.MapFrom(src=> src.BillingCycle.Name))
                    //.ForMember(dest => dest.ServiceName, act => act.MapFrom(src=> src.Service.Name))
                    .ReverseMap();
                mc.CreateMap<Language, LanguageDTO>().ReverseMap();
                mc.CreateMap<PhoneCode, PhoneCodeDTO>().ReverseMap();
                mc.CreateMap<Country, CountryDTO>().ReverseMap();
                mc.CreateMap<Service, ServiceDTO>().ReverseMap();
                //mc.CreateMap<Statement, Transaction>().ForMember(dest => dest.TransactionFromBankId,
                //    act => act.MapFrom(src => src.AppCode)).ForMember(dest => dest.Sum, act => act.MapFrom(src => float.Parse(src.Amount.Substring(0, src.Amount.Length - 4)))).ForMember(src => src.CreatedDate, opt => opt.MapFrom(s => DateTime.UtcNow));


                //.
            });

            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
