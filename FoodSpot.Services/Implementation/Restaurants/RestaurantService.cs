using AutoMapper;
using FoodSpot.Domain.Models.Addresses;
using FoodSpot.Domain.Models.Restaurants;
using FoodSpot.Domain.Models.Users;
using FoodSpot.DTOs.Request.Addresses;
using FoodSpot.DTOs.Request.Restaurants;
using FoodSpot.DTOs.Request.Users;
using FoodSpot.DTOs.Response.Addresses;
using FoodSpot.DTOs.Response.Addresses.Cities;
using FoodSpot.DTOs.Response.MenuItems;
using FoodSpot.DTOs.Response.Restaurants;
using FoodSpot.DTOs.Response.Users;
using FoodSpot.Infrastructure.Repositories.Interfaces.Addresses;
using FoodSpot.Infrastructure.Repositories.Interfaces.MenuItems;
using FoodSpot.Infrastructure.Repositories.Interfaces.Restaurants;
using FoodSpot.Infrastructure.Repositories.Interfaces.Users;
using FoodSpot.Services.Interfaces;
using FoodSpot.Services.Interfaces.Restaurants;
using Microsoft.Extensions.Configuration;
using NPOI.OpenXmlFormats;
using Org.BouncyCastle.Asn1.Ocsp;
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
        private readonly IMenuItemRepository _menuItemRepository;

        public RestaurantService(
            IMapper mapper,
            IUserRepository userRepository,
            IConfiguration configuration,
            IStateRepository stateRepository,
            ICityRepository cityRepository,
            IAddressRepository addressRepository,
            IRestaurantRepository restaurantRepository,
            IMenuItemRepository menuItemRepository
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _addressRepository = addressRepository;
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
        }
        public async Task<CreateRestaurantResponse> Create(CreateRestaurantRequest request)
        {
            if (await _userRepository.VerifyUserExists(request.UserRequest.Email))
                throw new Exception("User already exists");

            var user = CreateRestaurantUser(request.UserRequest);
            user = await _userRepository.CreateUser(user);

            var address = await CreateAddressWithLocationAsync(request.AddressRequest, user);
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

        public async Task<RestaurantResponse> GetById(Guid id)
        {
            Restaurant restaurant = await _restaurantRepository.GetById(id);

            if (restaurant == null)
                throw new Exception("Restaurant not found");

            return new()
            {
                Address = _mapper.Map<AddressResponse>(await GetAddressById(restaurant.AddressId)),
                Cnpj = restaurant.Cnpj,
                CreatedAt = restaurant.CreatedAt,
                User = _mapper.Map<UserWithoutPasswordResponse>(await GetUserById(restaurant.UserId)),
                Id = restaurant.Id,
                MenuItems = await GetMenuItemsByRestaurantIdAsync(restaurant),
            };
        }

        #region Auxiliaries

        private async Task<User> GetUserById(Guid userId)
        {
            User? user = await _userRepository.GetUserById(userId);
            if (user == null)
                throw new Exception("User not found");
            return user;
        }

        private async Task<AddressResponse> GetAddressById(Guid addressId)
        {
            Address? address = await _addressRepository.GetById(addressId);
            if (address == null)
                throw new Exception("User not found");

            AddressResponse response = _mapper.Map<AddressResponse>(address);
            City city = await _cityRepository.SelectById(address.CityId);
            State state = await _stateRepository.SelectById(address.StateId);

            response.City = city;
            response.City.State = state;
            return response;
        }

        private User CreateRestaurantUser(CreateUserOnObjectRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.UserType = UserType.Restaurant;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return user;
        }

        private async Task<Address> CreateAddressWithLocationAsync(CreateAddressRequest request, User user)
        {
            var state = await _stateRepository.SelectById(request.StateId)
                         ?? throw new Exception("Invalid state ID.");

            var city = await _cityRepository.SelectById(request.CityId)
                        ?? throw new Exception("Invalid city ID.");

            var address = _mapper.Map<Address>(request);
            address.User = user;
            address.State = state;
            address.City = city;
            address.UserId = user.Id;

            return address;
        }

        private async Task<ICollection<MenuItemResponse>> GetMenuItemsByRestaurantIdAsync(Restaurant restaurant)
        {
            ICollection<MenuItem> menuItems = await _menuItemRepository.GetByRestaurantId(restaurant.Id);
            ICollection<MenuItemResponse> menuItemsResponse = [];
            if (menuItems.Count > 0)
            {
                foreach (var item in menuItems)
                {
                    menuItemsResponse.Add(_mapper.Map<MenuItemResponse>(item));
                }
            }

            return menuItemsResponse;
        }

        #endregion
    }
}
