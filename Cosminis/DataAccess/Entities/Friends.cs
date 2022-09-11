using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Friends
    {
        public int UserFromFk { get; set; }
        public int UserToFk { get; set; }
        public string Status { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserFromFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserToFkNavigation { get; set; } = null!;
    }
}