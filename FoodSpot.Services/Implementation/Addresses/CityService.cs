using AutoMapper;
using FoodSpot.Domain.Models.Addresses;
using FoodSpot.DTOs.Response.Addresses.Cities;
using FoodSpot.Infrastructure.Repositories.Interfaces.Addresses;
using FoodSpot.Services.Interfaces.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSpot.Services.Implementation.Addresses
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<CityResponse> SelectById(int id)
        {
            City city = await _cityRepository.SelectById(id);
            return _mapper.Map<CityResponse>(city);
        }

        public async Task<IEnumerable<City>> SelectByStateId(int stateId)
        {
            IEnumerable<City> cities = await _cityRepository.SelectByStateId(stateId);
            return cities;
        }
    }
}
