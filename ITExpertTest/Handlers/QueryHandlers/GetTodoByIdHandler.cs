using AutoMapper;
using ITExpertTest.Interfaces;
using ITExpertTest.Queries;
using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Handlers.QueryHandlers;

public class GetTodoByIdHandler: IRequestHandler<GetTodoByIdQuery, TodoResponse?>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public GetTodoByIdHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoResponse?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodoByIdAsync(request.Id, cancellationToken);
        return todo == null ? null : _mapper.Map(todo, new TodoResponse());
    }
}