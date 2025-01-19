using Carly.App.Entities;

namespace Carly.App.Repositories
{
    internal interface IFuelTypeRepository
    {
        Task<IReadOnlyList<FuelType>> Browse();
    }
}
