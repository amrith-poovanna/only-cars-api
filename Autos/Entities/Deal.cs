using System;
using System.Collections.Generic;

namespace Auto.Entities
{
    public partial class Deal
    {
        public Guid DealId { get; set; }
        public Guid? CarId { get; set; }
        public DateTime? BuyDate { get; set; }
        public decimal? BuyCost { get; set; }
        public DateTime? SellDate { get; set; }
        public decimal? SellCost { get; set; }
        public bool? DealComplete { get; set; }

        public virtual Car? Car { get; set; }
    }
}
