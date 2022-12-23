using ITExpertTest.Models.Dtos;
using ITExpertTest.Models.Enums;
using ITExpertTest.Responses;
using MediatR;

namespace ITExpertTest.Commands;

public class CreateTodoCommand : IRequest<TodoResponse?>
{
    public string? Title { get; set; }
    public Category Category { get; set; }
    public Color Color { get; set; }
    
    public CreateTodoCommand(TodoAddDto todo)
    {
        Title = todo.Title;
        Category = todo.Category;
        Color = todo.Color;
    }
}