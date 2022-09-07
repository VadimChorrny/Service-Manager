using AutoMapper;
using Core.DTOs.Transactions;
using Core.DTOs.UserDTO;
using Core.Entities.TransactionEntity;
using Core.Entities.UserEntity;
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
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configures = new MapperConfiguration(mc =>
            {
                mc.CreateMap<User, UserDTO>().ReverseMap();
                mc.CreateMap<RegisterUserDTO, User>().ReverseMap();
                mc.CreateMap<TransactionDTO, Transaction>().ReverseMap(); //ForMember(dest => dest.);
            });

            IMapper mapper = configures.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
