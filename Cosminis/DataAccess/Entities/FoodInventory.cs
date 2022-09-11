using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class FoodInventory
    {
        public int UserFk { get; set; }
        public int FoodStatsFk { get; set; }
        public int FoodCount { get; set; }

        public virtual FoodStat FoodStatsFkNavigation { get; set; } = null!;
        public virtual User UserFkNavigation { get; set; } = null!;
    }
}
