using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Queries;

public class GetCommentariesByTodoIdQuery: IRequest<CommentariesResponse?>
{
    public int TodoId { get; }

    public GetCommentariesByTodoIdQuery(int todoId)
    {
        TodoId = todoId;
    }
}