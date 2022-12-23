using System.ComponentModel.DataAnnotations.Schema;

namespace ITExpertTest.Models.Entities;

public class Commentary
{
    public int Id { get; set; }
    public string? Content { get; set; }
    [ForeignKey(nameof(Entities.Todo))]
    public int TodoId { get; set; }
    public Todo? Todo { get; set; }
}