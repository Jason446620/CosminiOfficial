using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Companions = new HashSet<Companion>();
            FoodInventories = new HashSet<FoodInventory>();
            FriendUserFromFkNavigations = new HashSet<Friends>();
            FriendUserToFkNavigations = new HashSet<Friends>();
            Orders = new HashSet<Order>();
            Posts = new HashSet<Post>();
            PostFks = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime AccountAge { get; set; }
        public int GoldCount { get; set; }
        public int EggCount { get; set; }
        public int GemCount { get; set; }
        public DateTime EggTimer { get; set; }
        public int Notifications { get; set; }
        public string AboutMe { get; set; } = null!;
        public int? ShowcaseCompanionFk { get; set; }

        public virtual Companion? ShowcaseCompanionFkNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Companion> Companions { get; set; }
        public virtual ICollection<FoodInventory> FoodInventories { get; set; }
        public virtual ICollection<Friends> FriendUserFromFkNavigations { get; set; }
        public virtual ICollection<Friends> FriendUserToFkNavigations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Post> PostFks { get; set; }
    }
}
