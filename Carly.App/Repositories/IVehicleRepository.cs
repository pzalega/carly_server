using Carly.App.Entities;

namespace Carly.App.Repositories
{
    internal interface IVehicleRepository
    {
        Task Add(Vehicle vehicle);
        Task<IReadOnlyList<Vehicle>> Browse();
        Task<Vehicle?> Get(int id);
        Task<Vehicle?> Get(string name);
        Task Update(Vehicle car);
        Task Delete(Vehicle car);
    }
}
