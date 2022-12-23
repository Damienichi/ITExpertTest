using ITExpertTest.Models.Dtos;
using ITExpertTest.Models.Entities;
using ITExpertTest.Models.Enums;

namespace ITExpertTest.Responses;

public class TodoResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDone { get; set; }
    public Category Category { get; set; }
    public Color Color { get; set; }
    public ICollection<CommentaryDto>? Commentaries { get; set; }
}