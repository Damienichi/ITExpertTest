using ITExpertTest.Models.Entities;
using ITExpertTest.Models.Enums;

namespace ITExpertTest.Models.Dtos;

public class TodoDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDone { get; set; }
    public string Category { get; set; }
    public string Color { get; set; }
    public ICollection<CommentaryDto>? Commentaries { get; set; }
    public string? Hash { get; set; }
}