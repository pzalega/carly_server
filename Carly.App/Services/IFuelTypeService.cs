using Carly.App.DTO;

namespace Carly.App.Services
{
    public interface IFuelTypeService
    {
        Task<IEnumerable<FuelTypeDto>> GetAll();
    }
}
