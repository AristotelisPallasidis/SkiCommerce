using System;
using System.Linq.Expressions;
using SkiCommerce.Core.Interfaces;

namespace SkiCommerce.Core.Specifications;

public class Specification<T> : ISpecification<T>
{
    private readonly Expression<Func<T, bool>> criteria;
    
    public Specification(Expression<Func<T, bool>> criteria)
    {
        this.criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria => criteria;
}
