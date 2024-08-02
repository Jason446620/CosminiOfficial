using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Element
    {
        public Element()
        {
            SpeciesElementFkNavigations = new HashSet<Species>();
            SpeciesOpposingEleNavigations = new HashSet<Species>();
        }

        public int ElementId { get; set; }
        public string ElementType { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Species> SpeciesElementFkNavigations { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Species> SpeciesOpposingEleNavigations { get; set; }
    }
}
