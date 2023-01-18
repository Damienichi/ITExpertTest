using AutoMapper;
using ITExpertTest.Commands;
using ITExpertTest.Exceptions;
using ITExpertTest.Interfaces;
using ITExpertTest.Models.Entities;
using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Handlers.CommandHandlers;

public class CreateTodoHandler: IRequestHandler<CreateTodoCommand, TodoResponse?>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public CreateTodoHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoResponse?> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = _mapper.Map(request, new Todo());
        try
        {
            _todoRepository.Create(todo);
            return _mapper.Map(todo, new TodoResponse());
        }
        catch (Exception e)
        {
            throw new ErrorException()
            {
                ErrorMessage = e.Message,
                ErrorDescription = "Error while creating todo"
            };
        }
    }
}