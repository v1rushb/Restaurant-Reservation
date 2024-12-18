using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Utilities
{
    public class PaginationMetadataGenerator<T>
    {
        public Meta GetGeneratedMetadata(List<T> items, int page, int pageSize)
        {
            return new Meta
            {
                TotalItems = items.Count(),
                PageSize = pageSize,
                CurrentPage = page
            };
        }
    }
}
