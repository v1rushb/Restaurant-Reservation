
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreatedAsync().Wait();
        }

        public async Task<Table> CreateAsync(Table newTable)
        {
            var table = await _context.Tables.AddAsync(newTable);
            await _context.SaveChangesAsync();
            return table.Entity;
        }

        public async Task DeleteAsync(int Id)
        {
            var table = await GetByIdAsync(Id);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Table>> GetAllAsync(int size, int pageSize)
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetByIdAsync(int Id)
        {
            var table = await _context.Tables
                    .SingleOrDefaultAsync(table => table.TableId == Id);
            return table;
        }

        Task<int> IRepository<Table>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Table newTable)
        {
            _context.Tables.Update(newTable);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int Id) =>
            await _context.Tables.AnyAsync(table => table.TableId.Equals(Id));
    }
}