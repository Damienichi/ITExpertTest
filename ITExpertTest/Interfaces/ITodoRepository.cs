using System.Linq.Expressions;
using ITExpertTest.Models.Entities;

namespace ITExpertTest.Interfaces;

public interface ITodoRepository: IRepositoryBase<Todo>
{
    Task<IEnumerable<Todo>> GetAllTodosAsync(CancellationToken cancellationToken);
    Task<Todo?> GetTodoByIdAsync(int id, CancellationToken cancellationToken);
    Task<Todo?> UpdateTitle(int id, string newTitle, CancellationToken cancellationToken);
}