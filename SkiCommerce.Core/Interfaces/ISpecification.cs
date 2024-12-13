using System;
using System.Linq.Expressions;

namespace SkiCommerce.Core.Interfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
}
