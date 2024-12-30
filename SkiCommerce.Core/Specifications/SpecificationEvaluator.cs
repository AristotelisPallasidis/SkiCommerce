using SkiCommerce.Core.Entities;
using SkiCommerce.Core.Interfaces;

namespace SkiCommerce.Core.Data;

public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // x => x.Brand == brand from productrepository
        }

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }

        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }

        return query;
    }

    /// <summary>
    /// This functions is used to get the query with the specification and the result type of the query.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="spec"></param>
    /// <typeparam name="TSpec"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IQueryable<TResult> GetQuery<TSpec, TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // x => x.Brand == brand from productrepository
        }

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }

        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }

        var selectQuery = query as IQueryable<TResult>;


        if (spec.Select != null)
        {
            selectQuery = query.Select(spec.Select);
        }

        // the ?? is an alternative or a null coalescing operator
        return selectQuery ?? query.Cast<TResult>();
    }
}

