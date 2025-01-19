using Carly.App.DTO;
using Carly.App.Repositories;

namespace Carly.App.Services
{
    internal sealed class FuelTypeService : IFuelTypeService
    {
        private readonly IFuelTypeRepository _repository;

        public FuelTypeService(IFuelTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FuelTypeDto>> GetAll()
        {
            var fuelTypes = await _repository.Browse();

            if (fuelTypes is null)
            {
                return new List<FuelTypeDto>();
            }

            return fuelTypes.Select(x => new FuelTypeDto { Name = x.Name, Id = x.Id }).ToList();
        }
    }
}
