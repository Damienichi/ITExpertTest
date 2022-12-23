using ITExpertTest.Models.Dtos;

namespace ITExpertTest.Responses;

public class TodoListResponse
{
    public List<TodoDto>? Todos { get; set; }
}