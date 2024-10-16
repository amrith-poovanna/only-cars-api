namespace Autos.Models
{
    public class CarSummary
    {
        public Guid CarId { get; set; }
        public string RegistrationNo { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Varient { get; set; }
        public int ManufacturingYear { get; set; }
        public int RegistrationYear { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public int Driven { get; set; }
        public int Owners { get; set; }
        public bool? Sunroof { get; set; }
        public string Thumbnail {get; set;}
        public decimal? CoatPrice { get; set; }
        public string ImageName { get; set; }

    }
}
