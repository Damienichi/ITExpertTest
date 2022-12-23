using System.ComponentModel.DataAnnotations;

namespace ITExpertTest.Models.Dtos;

public class CommentaryAddDto
{
    [Required]
    public string? Content { get; set; }
    [Required]
    public int TodoId { get; set; }
}