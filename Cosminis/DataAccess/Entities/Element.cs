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

        public virtual ICollection<Species> SpeciesElementFkNavigations { get; set; }
        public virtual ICollection<Species> SpeciesOpposingEleNavigations { get; set; }
    }
}
