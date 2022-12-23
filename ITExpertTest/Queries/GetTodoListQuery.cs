using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Queries;

public class GetTodoListQuery : IRequest<TodoListResponse>
{
}