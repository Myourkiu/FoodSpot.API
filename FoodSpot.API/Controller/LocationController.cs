using FoodSpot.Domain.Models.Addresses;
using FoodSpot.DTOs.Request.Addresses;
using FoodSpot.Services.Interfaces.Addresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodSpot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;

        public LocationController(IStateService stateService, ICityService cityService)
        {
            _stateService = stateService;
            _cityService = cityService;
        }
        [HttpGet("states")]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            IEnumerable<State> states = await _stateService.Select();
            return Ok(states);
        }

        [HttpGet("cities/{id:int}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCityByState([FromRoute] int id)
        {
            IEnumerable<City> cities = await _cityService.SelectByStateId(id);
            return Ok(cities);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStates([FromForm] LocationImportRequest request)
        {

            await _stateService.ProcessStatesAndCitiesFile(request.FileData);
            return Ok();
        }
    }
}
