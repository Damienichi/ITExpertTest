using System.ComponentModel.DataAnnotations;
using ITExpertTest.Models.Enums;

namespace ITExpertTest.Models.Entities;

public class Todo
{
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsDone { get; set; }
    public Category Category { get; set; }
    public Color Color { get; set; }
    public ICollection<Commentary>? Commentaries { get; set; }
}