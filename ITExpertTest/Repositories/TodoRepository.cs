using ITExpertTest.Contexts;
using ITExpertTest.Interfaces;
using ITExpertTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITExpertTest.Repositories;

public class TodoRepository: RepositoryBase<Todo>, ITodoRepository
{
    public TodoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
    
    public async Task<IEnumerable<Todo>> GetAllTodosAsync(CancellationToken cancellationToken)
    {
        return await GetAll().Include(x=>x.Commentaries)
            .ToListAsync(cancellationToken);
    }

    public async Task<Todo?> GetTodoByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await GetByCondition(x=>x.Id == id).Include(x=>x.Commentaries).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Todo?> UpdateTitle(int id, string newTitle, CancellationToken cancellationToken)
    {
        var todoToUpdate = await GetTodoByIdAsync(id, cancellationToken);
        if (todoToUpdate != null)
        {
            todoToUpdate.Title = newTitle;
            Update(todoToUpdate);
        }

        return todoToUpdate;
    }
}