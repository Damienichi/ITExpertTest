using System.Linq.Expressions;
using ITExpertTest.Contexts;
using ITExpertTest.Exceptions;
using ITExpertTest.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ITExpertTest.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private RepositoryContext RepositoryContext { get; set; }

    protected RepositoryBase(RepositoryContext repositoryContext)
    {
        
        RepositoryContext = repositoryContext;
    }

    public IQueryable<T> GetAll() => RepositoryContext.Set<T>().AsNoTracking();

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity)
    {
        try
        {
            RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new UniquenessViolationException("Нарушение уникальности");
        }
    }

    public void Update(T entity)
    {
        try
        {
            RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new UniquenessViolationException("Нарушение уникальности");
        }
    }

    public void Delete(T entity)
    {
        RepositoryContext.Set<T>().Remove(entity);
        RepositoryContext.SaveChanges();
    }

    public void Save()
    {
        RepositoryContext.SaveChanges();
    }
}