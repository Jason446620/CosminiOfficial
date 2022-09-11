using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User
    {
        public override string ToString()
        { 
            int goldCount = this.GoldCount;
            int eggCount = this.EggCount;
            return String.Format("UserId: {0}, Username: {1}, GoldCount: {2}, EggCount: {3}, EggTimer: {4}", this.UserId, this.Username, goldCount, eggCount, EggTimer.ToString());
        }  

        
        public User(int UserId, string username, DateTime AccountAge, string password, int Goldcount, int Eggcount, DateTime Eggtimer)
        {
            this.UserId = UserId;

            this.Username = username;

            this.Password = password;

            this.GoldCount = Goldcount;

            this.EggCount = Eggcount;

            this.EggTimer = Eggtimer;

            this.AccountAge = AccountAge;
        }
    }
}
