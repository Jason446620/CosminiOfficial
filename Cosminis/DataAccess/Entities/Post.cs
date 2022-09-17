using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            UserFks = new HashSet<User>();
        }

        public int PostId { get; set; }
        public int UserFk { get; set; }
        public string Content { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<User> UserFks { get; set; }
    }
}
