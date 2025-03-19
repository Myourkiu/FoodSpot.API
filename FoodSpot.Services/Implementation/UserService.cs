using AutoMapper;
using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.DTOs.Response.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Users;
using FoodSpot.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            bool userExist = await VerifyUserExistsByEmail(request.Email);

            if (userExist)
                throw new Exception("User already exists");

            if (string.IsNullOrEmpty(request.Password))
                throw new Exception("Password must have a value");

            User mappedUser = _mapper.Map<User>(request);

            mappedUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            mappedUser = await _userRepository.CreateUser(mappedUser);

            return _mapper.Map<CreateUserResponse>(mappedUser);
        }

        #region Auxiliaries
        private async Task<bool> VerifyUserExistsByEmail (string email)
        {
           bool verify = await _userRepository.VerifyUserExists(email);
            return verify;
        }
        #endregion
    }
}
