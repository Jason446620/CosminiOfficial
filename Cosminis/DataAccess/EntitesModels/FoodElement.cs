using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{   
    public partial class FoodElement
    {
        public override string ToString()
        { 
            return $"FoodElementId: {this.FoodElementId}, FoodElement: {this.FoodElement1}";
        }  
    }
}