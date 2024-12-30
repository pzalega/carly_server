using Carly.App.DTO;

namespace Carly.App.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleDto>> GetAll();
        Task<VehicleDto> Get(int id);
    }
}
