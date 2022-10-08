using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Companion
    {
        public Companion()
        {
            Users = new HashSet<User>();
        }

        public int CompanionId { get; set; }
        public int UserFk { get; set; }
        public int SpeciesFk { get; set; }
        public int Emotion { get; set; }
        public string Nickname { get; set; } = null!;
        public int Hunger { get; set; }
        public int Mood { get; set; }
        public DateTime TimeSinceLastChangedMood { get; set; } = DateTime.Now;
        public DateTime TimeSinceLastChangedHunger { get; set; } = DateTime.Now;
        public DateTime TimeSinceLastPet { get; set; } = DateTime.Now;
        public DateTime CompanionBirthday { get; set; } = DateTime.Now;
        public DateTime TimeSinceLastFed { get; set; } = DateTime.Now;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual EmotionChart EmotionNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Species SpeciesFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
