using AutoMapper;
using ITExpertTest.Interfaces;
using ITExpertTest.Models.Dtos;
using ITExpertTest.Queries;
using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Handlers.QueryHandlers;

public class GetCommentariesByTodoIdHandler: IRequestHandler<GetCommentariesByTodoIdQuery, CommentariesResponse?>
{
    private readonly ICommentaryRepository _repository;
    private readonly IMapper _mapper;

    public GetCommentariesByTodoIdHandler(ICommentaryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CommentariesResponse?> Handle(GetCommentariesByTodoIdQuery request, CancellationToken cancellationToken)
    {
        var commentaries = await _repository.GetCommentariesByTodoId(request.TodoId);
        var commentariesDto = _mapper.Map(commentaries, new List<CommentaryDto>());
        
        return new CommentariesResponse {Commentaries = commentariesDto};
    }
}