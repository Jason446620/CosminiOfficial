export interface Posts
{
    postId : number;
    userFk : number;
    content : string;
    posterNickname?:string;
}