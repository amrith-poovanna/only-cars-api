using System;
using System.Collections.Generic;

namespace Auto.Entities
{
    public partial class Car
    {
        public Car()
        {
            Buyers = new HashSet<Buyer>();
            Commissions = new HashSet<Commission>();
            Deals = new HashSet<Deal>();
            Sellers = new HashSet<Seller>();
        }

        public Guid CarId { get; set; }
        public string RegistrationNo { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Varient { get; set; }
        public int ManufacturingYear { get; set; }
        public int RegistrationYear { get; set; }
        public string FuelType { get; set; } = null!;
        public string Transmission { get; set; } = null!;
        public int Driven { get; set; }
        public int Owners { get; set; }
        public bool? Sunroof { get; set; }
        public DateTime InsuranceExpiry { get; set; }
        public string? InsuranceType { get; set; }
        public bool? Alloys { get; set; }
        public string? Colour { get; set; }
        public int? Seats { get; set; }
        public int? Doors { get; set; }
        public string? Description { get; set; }
        public decimal? CoatPrice { get; set; }

        public virtual ICollection<Buyer> Buyers { get; set; }
        public virtual ICollection<Commission> Commissions { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
