using ITExpertTest.Models.Entities;

namespace ITExpertTest.Interfaces;

public interface ICommentaryRepository: IRepositoryBase<Commentary>
{
    Task<IEnumerable<Commentary>> GetCommentariesByTodoId(int todoId);
    Task<Commentary> AddCommentaryToTodoByIdAsync(Commentary commentary);
}