namespace Carly.App.Entities
{
    internal sealed class Refuel
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateOnly RefuelDate { get; set; }
        public decimal FuelLitres { get; set; }
        public decimal LitrePrice { get; set; }
        public decimal RefuelPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
