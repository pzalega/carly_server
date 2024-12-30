namespace Carly.App.Entities
{
    internal sealed class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Refuel> Refuels { get; set; }

        public Vehicle()
        {
            Refuels = new List<Refuel>();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
