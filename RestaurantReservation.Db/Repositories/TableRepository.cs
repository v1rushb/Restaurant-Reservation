using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        Task<int> IRepository<Table>.CreateAsync(Table entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Table>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<Table>> IRepository<Table>.GetAllAsync(Table entity)
        {
            throw new NotImplementedException();
        }

        Task<Table> IRepository<Table>.GetByIdAsync(Table entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Table>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Table>.UpdateAsync(Table entity)
        {
            throw new NotImplementedException();
        }
    }
}
