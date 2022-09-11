using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Species
    {
        public Species()
        {
            Companions = new HashSet<Companion>();
            Conversations = new HashSet<Conversation>();
        }

        public int SpeciesId { get; set; }
        public int ElementFk { get; set; }
        public int OpposingEle { get; set; }
        public int FoodElementFk { get; set; }
        public int OppFoodElementFk { get; set; }
        public int ClassFk { get; set; }
        public string SpeciesName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsMega { get; set; }

        public virtual Class ClassFkNavigation { get; set; } = null!;
        public virtual Element ElementFkNavigation { get; set; } = null!;
        public virtual FoodElement FoodElementFkNavigation { get; set; } = null!;
        public virtual FoodElement OppFoodElementFkNavigation { get; set; } = null!;
        public virtual Element OpposingEleNavigation { get; set; } = null!;
        public virtual ICollection<Companion> Companions { get; set; }
        public virtual ICollection<Conversation> Conversations { get; set; }
    }
}
