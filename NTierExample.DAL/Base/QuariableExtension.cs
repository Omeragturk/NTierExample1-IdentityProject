using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;

namespace TierExample.DAL.Base
{
    public static class QuariableExtension
    {
        public static IQueryable<T> MyInculudes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if(query is not null)
            {
                query = includes.Aggregate(query, (a,b) => a.Include(b));   
            }

            return query;
        }
    }
}
