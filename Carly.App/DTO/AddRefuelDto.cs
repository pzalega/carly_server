namespace Carly.App.DTO
{
    public class AddRefuelDto
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime FillUpDate { get; set; }
        public decimal FuelLitres { get; set; }
        public decimal LitrePrice { get; set; }
        public decimal FillUpPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
