using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int UserFk { get; set; }
        public decimal Cost { get; set; }
        public int Gems { get; set; }
        public DateTime TimeOrdered { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserFkNavigation { get; set; } = null!;
    }
}
