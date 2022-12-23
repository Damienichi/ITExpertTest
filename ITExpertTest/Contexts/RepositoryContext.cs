using ITExpertTest.Models.Entities;
using ITExpertTest.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITExpertTest.Contexts;

public sealed class RepositoryContext: DbContext
{
    public DbSet<Todo>? Todos { get; set; }
    public DbSet<Commentary>? Commentaries { get; set; }

    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>(TodoConfigure);
        modelBuilder.Entity<Commentary>(CommentaryConfigure);
    }

    private void TodoConfigure(EntityTypeBuilder<Todo> builder)
    {
        builder.Property(e => e.Category)
            .HasConversion(
                x => x.ToString(),
                x => (Category)Enum.Parse(typeof(Category), x));
        builder.Property(e => e.Color)
            .HasConversion(
                x => x.ToString(),
                x => (Color)Enum.Parse(typeof(Color), x));
        
        builder.HasIndex(b => b.Title).IsUnique();
        builder.HasIndex(b => b.Category).IsUnique();
        
        builder.HasData(
            new Todo { Id = 1, Title = "Create a ticket ", Category = Category.Analytics, Color = Color.Red },
            new Todo { Id = 2, Title = "Request information", Category = Category.Bookkeeping, Color = Color.Green }
        );
    }

    private void CommentaryConfigure(EntityTypeBuilder<Commentary> builder)
    {
        builder.HasData(
            new Commentary { Id = 1, Content = "Commentary 1", TodoId = 1 },
            new Commentary { Id = 2, Content = "Commentary 2", TodoId = 1 },
            new Commentary { Id = 3, Content = "Commentary 3", TodoId = 1 }
        );
    }
}