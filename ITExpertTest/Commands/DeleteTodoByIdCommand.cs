using MediatR;

namespace ITExpertTest.Commands;

public class DeleteTodoByIdCommand: IRequest<bool>
{
    public int Id { get; set; }

    public DeleteTodoByIdCommand(int id)
    {
        Id = id;
    }
}