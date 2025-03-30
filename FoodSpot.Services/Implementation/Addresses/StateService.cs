using AutoMapper;
using FoodSpot.Domain.Models.Addresses;
using FoodSpot.DTOs.Response.Addresses.States;
using FoodSpot.Infrastructure.Repositories.Interfaces.Addresses;
using FoodSpot.Services.Interfaces.Addresses;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace FoodSpot.Services.Implementation.Addresses
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public StateService(IStateRepository stateRepository, IMapper mapper, ICityRepository cityRepository)
        {
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task ProcessStatesAndCitiesFile(IFormFile file)
        {
            var states = new List<State>();
            var cities = new List<City>();

            // Use the MemoryStream inside the 'using' statement
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                // Reset the stream position to the beginning
                stream.Position = 0;

                IWorkbook workbook;
                if (Path.GetExtension(file.FileName).Equals(".xls"))
                {
                    workbook = new HSSFWorkbook(stream); // Excel 97-2003
                }
                else
                {
                    workbook = new XSSFWorkbook(stream); // Excel 2007+
                }

                var sheet = workbook.GetSheetAt(0);
                for (int row = 1; row <= sheet.LastRowNum; row++)
                {
                    var currentRow = sheet.GetRow(row);
                    if (currentRow == null)
                        continue;
                    if (currentRow.GetCell(1) == null)
                        break;

                    var stateId = int.Parse(currentRow.GetCell(1).ToString()); // CD_UF

                    if (!states.Exists(s => s.Id == stateId))
                    {
                        var state = new State
                        {
                            Id = stateId,
                            Name = currentRow.GetCell(2).ToString(), // NM_UF
                            UF = currentRow.GetCell(3).ToString() // NM_UF_SIGLA
                        };

                        states.Add(state);
                    }

                    var city = new City
                    {
                        Id = int.Parse(currentRow.GetCell(4).ToString()), // CD_MUN
                        StateId = stateId,
                        Name = currentRow.GetCell(5).ToString() // NM_MUN
                    };

                    cities.Add(city);
                }
            }

            await _stateRepository.BulkInsertStates(states);
            await _cityRepository.BulkInsertCities(cities);
        }


        public async Task<IEnumerable<State>> Select()
        {
            IEnumerable<State> states = await _stateRepository.Select();
            return states.ToList();
        }

        public async Task<StateResponse> SelectById(int id)
        {
            State state = await _stateRepository.SelectById(id);
            return _mapper.Map<StateResponse>(state);
        }
    }
}
