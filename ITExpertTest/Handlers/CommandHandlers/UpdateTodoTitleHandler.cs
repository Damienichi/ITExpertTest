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
        Todo? todo;
        try
        {
           todo = await _todoRepository.UpdateTitle(request.Id, request.NewTitle, cancellationToken);
        }
        catch (UniquenessViolationException e)
        {
            // TODO: Логгирование и обработка ошибки
            return null;
        }
        
        return _mapper.Map(todo, new TodoResponse());
    }
}