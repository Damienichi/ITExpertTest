using ITExpertTest.Models.Enums;

namespace ITExpertTest.Models.Dtos;

public class TodoAddDto
{
    public string? Title { get; set; }
    public Category Category { get; set; }
    public Color Color { get; set; }
}