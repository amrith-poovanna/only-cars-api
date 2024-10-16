using System;
using System.Collections.Generic;

namespace Auto.Entities
{
    public partial class CommissionType
    {
        public CommissionType()
        {
            Commissions = new HashSet<Commission>();
        }

        public int CommissionTypeId { get; set; }
        public string? CommissionTypeName { get; set; }

        public virtual ICollection<Commission> Commissions { get; set; }
    }
}
