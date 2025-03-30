using AutoMapper;
using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Addresses;
using FoodSpot.DTOs.Request.Restaurants;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.DTOs.Response.Addresses.Cities;
using FoodSpot.DTOs.Response.Addresses.States;
using FoodSpot.DTOs.Response.Users;

namespace FoodSpot.API.AutoMapper
{
    public class Mappings : Profile
    {

        public Mappings()
        {
            #region User

            CreateMap<CreateUserRequest, User>();
            CreateMap<CreateUserOnObjectRequest, User>();
            CreateMap<User, UserWithoutPasswordResponse>().ReverseMap();
            CreateMap<User, UserLoginResponse>().ReverseMap();
            CreateMap<EditUserRequest, User>();

            #endregion

            #region State

            CreateMap<State, StateResponse>().ReverseMap();

            #endregion

            #region City

            CreateMap<City, CityResponse>().ReverseMap();
            CreateMap<AddCityRequest, City>();

            #endregion

            #region Restaurant

            CreateMap<CreateRestaurantRequest, Restaurant>();

            #endregion

            #region Address

            CreateMap<CreateAddressRequest, Address>();

            #endregion
        }
    }
}
