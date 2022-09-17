export interface Comment 
{
    commentId : number;
    userFk : number;
    postFk : number;
    content : string;
    commenter? : string;
}