using ITExpertTest.Models.Dtos;
using ITExpertTest.Models.Entities;
using MediatR;

namespace ITExpertTest.Commands;

public class AddCommentaryToTodoByIdCommand: IRequest<Commentary>
{
    public string? Content { get; set; }
    public int TodoId { get; set; }

    public AddCommentaryToTodoByIdCommand(CommentaryAddDto commentary)
    {
        Content = commentary.Content;
        TodoId = commentary.TodoId;
    }
}