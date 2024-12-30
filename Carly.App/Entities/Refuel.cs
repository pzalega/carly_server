using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carly.App.Entities
{
    internal sealed class Refuel
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateOnly RefuelDate { get; set; }
        public decimal FuelLitres { get; set; }
        public decimal LitrePrice { get; set; }
        public decimal RefuelPrice { get; set; }
        public DateTime CreatedAt { get; set; }

        public Refuel()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
