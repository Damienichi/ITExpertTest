using ITExpertTest.Contexts;
using ITExpertTest.Interfaces;
using ITExpertTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITExpertTest.Repositories;

public class CommentaryRepository: RepositoryBase<Commentary>, ICommentaryRepository
{
    public CommentaryRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Commentary>> GetCommentariesByTodoId(int todoId)
    {
        return await GetAll().Where(x=>x.TodoId == todoId).ToListAsync();
    }

    public Task<Commentary> AddCommentaryToTodoByIdAsync(Commentary commentary)
    { 
        Create(commentary);
        return Task.FromResult(commentary);
    }
}
