namespace DataAccess.Entities;

public partial class Comment
    { 
        public override string ToString()
        { 
            return 
                $"CommentId: {this.CommentId}, " + 
                $"UserId: {this.UserFk}, " +
                $"PostIdFk: {this.PostFk}, " +
                $"Content: {this.Content} "; 
        }  
    }