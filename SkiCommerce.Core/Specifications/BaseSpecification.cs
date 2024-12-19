using System;
using System.Linq.Expressions;
using SkiCommerce.Core.Interfaces;

namespace SkiCommerce.Core.Specifications;

public class Specification<T>(Expression<Func<T, bool>> criteria) : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
}

