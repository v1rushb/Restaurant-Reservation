using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<List<T>> PaginateAsync<T> (
            this IQueryable<T> query,
            int page,
            int pageSize)
        {
            var Items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Items;
        }  
    }
}