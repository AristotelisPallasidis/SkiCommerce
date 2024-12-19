using System;
using System.Linq.Expressions;

namespace SkiCommerce.Core.Interfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }
    Expression<Func<T, object>>? OrderBy { get; }
    Expression<Func<T, object>>? OrderByDescending { get; }
}

public interface ISpecificationResult<T, TResult> : ISpecification<T>
{
    Expression<Func<T, TResult>>? Select { get; }
}