using Carly.App.DTO;

namespace Carly.App.Services
{
    public interface IVehicleService
    {
        Task Add(VehicleDto car);
        Task<IEnumerable<VehicleDto>> GetAll();
        Task<VehicleDto> Get(int id);
        Task Update(int id, VehicleDto car);
        Task Delete(int id);
    }
}
