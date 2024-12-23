namespace Carly.App.Entities
{
    internal sealed class Vehicle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreatedAt { get; set; }
        public ICollection<Refuel> Refuels { get; set; }

        public Vehicle()
        {
            Refuels = new List<Refuel>();
        }
    }
}
