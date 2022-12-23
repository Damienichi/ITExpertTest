using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Commands;

public class UpdateTodoTitleCommand: IRequest<TodoResponse?>
{
    public int Id { get; set; }
    public string NewTitle { get; set; }
    public UpdateTodoTitleCommand(string newTitle, int id)
    {
        NewTitle = newTitle;
        Id = id;
    }
}