using AutoMapper;
using ITExpertTest.Interfaces;
using ITExpertTest.Models.Dtos;
using ITExpertTest.Queries;
using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Handlers.QueryHandlers;

public class GetTodoListHandler: IRequestHandler<GetTodoListQuery, TodoListResponse>
{
    private readonly ITodoRepository _repository;
    private readonly IMapper _mapper;
    
    public GetTodoListHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _repository = todoRepository;
        _mapper = mapper;
    }
    public async Task<TodoListResponse> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
    {
        var todoList = await _repository.GetAllTodosAsync(cancellationToken);
        var todoDtos = _mapper.Map(todoList, new List<TodoDto>());

        return new TodoListResponse(){ Todos = todoDtos };
    }
}