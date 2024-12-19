using System;
using System.Linq.Expressions;
using SkiCommerce.Core.Entities;

namespace SkiCommerce.Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T?> GetEntityWithSpec(ISpecification<T> specs);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specs);
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<bool> SaveAllAsync();
    bool Exists(int id);
}
