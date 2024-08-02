using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Class
    {
        public Class()
        {
            Species = new HashSet<Species>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; } = null!;
        public int BaseStr { get; set; }
        public int BaseDex { get; set; }
        public int BaseInt { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Species> Species { get; set; }
    }
}
