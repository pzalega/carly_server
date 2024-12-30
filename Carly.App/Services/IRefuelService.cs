using Carly.App.DTO;

namespace Carly.App.Services
{
    public interface IRefuelService
    {
        Task RefuelVehicle(int vehicleId, AddRefuelDto refuelDto);
        Task<IEnumerable<RefuelDto>> GetAll();
    }
}
