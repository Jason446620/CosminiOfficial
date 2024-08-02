using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int UserFk { get; set; }
        public int PostFk { get; set; }
        public string Content { get; set; } = null!;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Post PostFkNavigation { get; set; } = null!;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual User UserFkNavigation { get; set; } = null!;
    }
}
