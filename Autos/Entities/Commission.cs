using System;
using System.Collections.Generic;

namespace Auto.Entities
{
    public partial class Commission
    {
        public Guid CommissionId { get; set; }
        public Guid? CarId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Commission1 { get; set; }
        public string? Agent { get; set; }
        public int? CommissionTypeId { get; set; }

        public virtual Car? Car { get; set; }
        public virtual CommissionType? CommissionType { get; set; }
    }
}
