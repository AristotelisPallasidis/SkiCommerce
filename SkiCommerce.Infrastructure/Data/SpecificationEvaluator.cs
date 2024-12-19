using System;
using System.Linq;
using SkiCommerce.Core.Entities;
using SkiCommerce.Core.Interfaces;

namespace SkiCommerce.Infrastructure.Data;

public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> specs)
    {
        if (specs.Criteria != null)
        {
            query= query.Where(specs.Criteria); // x => x.Brand == brand
        }

        return query;
    }
}
