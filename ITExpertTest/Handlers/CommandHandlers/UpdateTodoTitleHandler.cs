using AutoMapper;
using ITExpertTest.Commands;
using ITExpertTest.Exceptions;
using ITExpertTest.Interfaces;
using ITExpertTest.Models.Entities;
using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Handlers.CommandHandlers;

public class UpdateTodoTitleHandler: IRequestHandler<UpdateTodoTitleCommand, TodoResponse?>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public UpdateTodoTitleHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<TodoResponse?> Handle(UpdateTodoTitleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todo = await _todoRepository.UpdateTitle(request.Id, request.NewTitle, cancellationToken);
            return _mapper.Map(todo, new TodoResponse());
        }
        catch (Exception e)
        {
            throw new ErrorException()
            {
                ErrorMessage = e.Message,
                ErrorDescription = "Error while updating todo title"
            };
        }
    }
}