using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Companion
    { 
        public override string ToString()
        { 
            return 
                $"CreatureId: {this.CompanionId}, " + 
                $"Nickname: {this.Nickname}, " + 
                $"Hunger: {this.Hunger}"; 
        }  
    }
}







   
   
