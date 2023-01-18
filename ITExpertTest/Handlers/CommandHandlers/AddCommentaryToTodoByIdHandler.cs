using AutoMapper;
using ITExpertTest.Commands;
using ITExpertTest.Exceptions;
using ITExpertTest.Interfaces;
using ITExpertTest.Models.Entities;
using MediatR;

namespace ITExpertTest.Handlers.CommandHandlers;

public class AddCommentaryToTodoByIdHandler: IRequestHandler<AddCommentaryToTodoByIdCommand, Commentary?>
{
    private readonly ICommentaryRepository _repository;
    private readonly IMapper _mapper;

    public AddCommentaryToTodoByIdHandler(ICommentaryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Commentary?> Handle(AddCommentaryToTodoByIdCommand request, CancellationToken cancellationToken)
    {
        var commentary = _mapper.Map(request, new Commentary());
        try
        {
            _repository.Create(commentary);
        }
        catch (Exception e)
        {
            throw new ErrorException()
            {
                ErrorMessage = e.Message,
                ErrorDescription = "Error while adding commentary"
            };
        }

        return commentary;
    }
}