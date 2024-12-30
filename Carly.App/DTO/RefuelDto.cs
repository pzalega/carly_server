namespace Carly.App.DTO
{
    public class RefuelDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public DateTime FillUpDate { get; set; }
        public decimal FuelLitres { get; set; }
        public decimal LitrePrice { get; set; }
        public decimal FillUpPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
