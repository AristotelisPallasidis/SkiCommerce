using System;
using System.Linq;
using SkiCommerce.Core.Entities;
using SkiCommerce.Core.Interfaces;

namespace SkiCommerce.Infrastructure.Data;

public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query= query.Where(spec.Criteria); // x => x.Brand == brand
        }

        if (spec.OrderBy != null)
        {
            query= query.OrderBy(spec.OrderBy); // x => x.Brand == brand
        }
        
        if (spec.OrderByDescending != null)
        {
            query= query.OrderByDescending(spec.OrderByDescending);
        }

        if (spec.IsDistinct)
        {
            query= query.Distinct();
        }

        if (spec.IsPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        return query;
    }

    /// <summary>
    /// This function is used to get the query with the result type of TResult
    /// from the query with the specification of TSpec type.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="spec"></param>
    /// <typeparam name="TSpec"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IQueryable<TResult> GetQuery<TSpec, TResult>(IQueryable<T> query,
        ISpecification<T, TResult> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // x => x.Brand == brand
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

        if (spec.IsDistinct)
        {
            selectQuery = selectQuery?.Distinct();
        }

        if (spec.IsPagingEnabled)
        {
            selectQuery = selectQuery?.Skip(spec.Skip).Take(spec.Take);
        }

        return selectQuery ?? query.Cast<TResult>();
    }

}
