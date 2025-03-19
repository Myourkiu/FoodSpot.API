﻿using AutoMapper;
using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.DTOs.Response.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Users;
using FoodSpot.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        public UserService(
            IMapper mapper,
            IUserRepository userRepository,
            ITokenService tokenService,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
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

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            User? user = await _userRepository.GetUserByEmail(request.Email);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                throw new Exception("Email or Password invalid");

            UserLoginResponse response = _mapper.Map<UserLoginResponse>(user);

            string token = await _tokenService.GenerateToken(response, _configuration);

            response.Token = token;

            return response;

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
