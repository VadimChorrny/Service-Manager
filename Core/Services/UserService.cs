using AutoMapper;
using Core.DTOs.UserDTO;
using Core.Entities.UserEntity;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        // METHODS FOR SERVICES
        public async Task Create(UserDTO user)
        {
            if (user == null)
                throw new HttpException($"Error with create new user!", HttpStatusCode.NotFound);
            await _unitOfWork.UserRepository.Insert(_mapper.Map<User>(user));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            if (id == null) throw new HttpException($"Invalid id!", HttpStatusCode.NotFound);
            var user = _unitOfWork.UserRepository.GetById(id);
            if (user != null)
                await _unitOfWork.UserRepository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Edit(UserDTO user)
        {
            if (user == null)
                throw new HttpException($"Error with edit user!", HttpStatusCode.NotFound);
            _unitOfWork.UserRepository.Update(_mapper.Map<User>(user));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _unitOfWork.UserRepository.Get());
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            if (id == null) throw new HttpException($"Invalid id!", HttpStatusCode.BadGateway);
            var user = _unitOfWork.UserRepository.GetById(id);
            if (user == null) throw new HttpException($"User Not Found!", HttpStatusCode.NotFound);
            return _mapper.Map<UserDTO>(await user);
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            if (email == null)
                throw new HttpException($"Invalid email!", HttpStatusCode.BadGateway);
            var user = _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new HttpException($"User with this email not found!",
                    HttpStatusCode.NotFound);
            return _mapper.Map<UserDTO>(await user);
        }
    }
}
