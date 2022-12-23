using AutoMapper;
using ITExpertTest.Commands;
using ITExpertTest.Exceptions;
using ITExpertTest.Interfaces;
using MediatR;

namespace ITExpertTest.Handlers.CommandHandlers;

public class DeleteTodoByIdHandler: IRequestHandler<DeleteTodoByIdCommand, bool>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;

    public DeleteTodoByIdHandler(ITodoRepository todoRepository, IMapper mapper)
    {
        _todoRepository = todoRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteTodoByIdCommand request, CancellationToken cancellationToken)
    {
        var todo = _todoRepository.GetByCondition(x => x.Id == request.Id).FirstOrDefault();
        if (todo == null)
        {
            return false;
        }
        try
        {
            _todoRepository.Delete(todo);
        }
        catch (Exception e)
        {
            // TODO: Логгирование и обработка ошибки
            return false;
        }

        return true;
    }
}