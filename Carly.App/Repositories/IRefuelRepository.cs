using Carly.App.Entities;

namespace Carly.App.Repositories
{
    internal interface IRefuelRepository
    {
        Task<IReadOnlyList<Refuel>> Browse();
    }
}
