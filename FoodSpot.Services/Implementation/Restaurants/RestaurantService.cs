using AutoMapper;
using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Addresses;
using FoodSpot.DTOs.Request.Restaurants;
using FoodSpot.DTOs.Response.Addresses;
using FoodSpot.DTOs.Response.Restaurants;
using FoodSpot.DTOs.Response.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Addresses;
using FoodSpot.Infrastructure.Repositories.Interfaces.Restaurants;
using FoodSpot.Infrastructure.Repositories.Interfaces.Users;
using FoodSpot.Services.Interfaces;
using FoodSpot.Services.Interfaces.Restaurants;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Implementation.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IRestaurantRepository _restaurantRepository;
        
        public RestaurantService(
            IMapper mapper,
            IUserRepository userRepository,
            ITokenService tokenService,
            IConfiguration configuration,
            IStateRepository stateRepository,
            ICityRepository cityRepository,
            IAddressRepository addressRepository,
            IRestaurantRepository restaurantRepository
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _addressRepository = addressRepository;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<CreateRestaurantResponse> Create(CreateRestaurantRequest request)
        {
            var verifyUserExists = await _userRepository.VerifyUserExists(request.UserRequest.Email);

            if (verifyUserExists)
                throw new Exception("User already exists");

            User user = _mapper.Map<User>(request.UserRequest);

            user.UserType = UserType.Restaurant;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user = await _userRepository.CreateUser(user);

            UserWithoutPasswordResponse userResponse = _mapper.Map<UserWithoutPasswordResponse>(user);

            State state = await _stateRepository.SelectById(request.AddressRequest.StateId);
            City city = await _cityRepository.SelectById(request.AddressRequest.CityId);

            Address address = _mapper.Map<Address>(request.AddressRequest);

            address.City = city;
            address.State = state;

            address.UserId = user.Id;
            address.User = user;

            address = await _addressRepository.Create(address);
            AddressResponse addressResponse = _mapper.Map<AddressResponse>(address);

            Restaurant restaurant = new()
            {
                UserId = user.Id,
                User = user,
                Address = address,
                AddressId = address.Id,
                Cnpj = request.Cnpj
            };

            restaurant = await _restaurantRepository.Create(restaurant);

            CreateRestaurantResponse response = _mapper.Map<CreateRestaurantResponse>(restaurant);

            return response;

        }
    }
}
