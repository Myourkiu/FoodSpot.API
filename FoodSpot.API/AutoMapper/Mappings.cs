﻿using AutoMapper;
using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.DTOs.Response.Users;

namespace FoodSpot.API.AutoMapper
{
    public class Mappings : Profile
    {

        public Mappings()
        {
         #region User

            CreateMap<CreateUserRequest, User>();
            CreateMap<User, UserWithoutPasswordResponse>().ReverseMap();
            CreateMap<User, UserLoginResponse>().ReverseMap();
            CreateMap<EditUserRequest, User>();

         #endregion
        }
    }
}
