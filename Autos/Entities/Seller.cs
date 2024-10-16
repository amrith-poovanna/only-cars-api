using System;
using System.Collections.Generic;

namespace Auto.Entities
{
    public partial class Seller
    {
        public Guid SellerId { get; set; }
        public Guid? CarId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string ContactNumber { get; set; } = null!;
        public string? IdType { get; set; }
        public string? IdNumber { get; set; }
        public string? IdImage { get; set; }

        public virtual Car? Car { get; set; }
    }
}
