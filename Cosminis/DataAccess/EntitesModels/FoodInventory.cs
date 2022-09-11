using System.Collections.Generic;
using DataAccess;

namespace DataAccess.Entities;
    public partial class FoodInventory
    {
        public override string ToString()
        {
            return
                $"UserFK: {this.UserFk}, " +
                $"FoodFK: {this.FoodStatsFk}, " + 
                $"FoodCount: {this.FoodCount}";
        }
    }
