using Carly.App.DTO;

namespace Carly.App.Services
{
    public interface IVehicleService
    {
        Task Add(VehicleDto car);
        Task<IEnumerable<VehicleDto>> GetAll();
        Task<VehicleDto> Get(Guid id);
        Task Update(Guid id, VehicleDto car);
        Task Delete(Guid id);
    }
}
