using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Queries;

public class GetTodoByIdQuery : IRequest<TodoResponse>
{
    public int Id { get; }
    public GetTodoByIdQuery(int id)
    {
        Id = id;
    }
}