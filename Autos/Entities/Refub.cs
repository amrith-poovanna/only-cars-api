using System;
using System.Collections.Generic;

namespace Auto.Entities
{
    public partial class Refub
    {
        public Guid? CarId { get; set; }
        public string? RefubType { get; set; }
        public decimal? Cost { get; set; }

        public virtual Car? Car { get; set; }
    }
}
