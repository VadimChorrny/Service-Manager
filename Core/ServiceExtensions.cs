using AutoMapper;
using Core.DTOs.Subscriptions;
using Core.DTOs.Transactions;
using Core.DTOs.UserDTO;
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
            services.AddScoped<ISubscriptionService, SubscriptionService>();
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
                    .ForMember(dest => dest.BillingCycle, act => act.MapFrom(src=> src.BillingCycle.Name))
                    .ForMember(dest => dest.ServiceName, act => act.MapFrom(src=> src.Service.Name))
                    .ReverseMap();
            });

            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
