using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Friends
    {
        public int userFromFk { get; set; }
        public int userToFk { get; set; }
        public string Status { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User userFromFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User userToFkNavigation { get; set; } = null!;
    }
}