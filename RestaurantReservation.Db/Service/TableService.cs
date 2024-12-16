using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;

namespace RestaurantReservation.Db.Service
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<int> CreateAsync(Table newTable)
        {
            return await _tableRepository.CreateAsync(newTable);
        }
        public async Task DeleteAsync(int tableId)
        {
            await _tableRepository.DeleteAsync(tableId);
        }

        public async Task<List<Table>> GetAllAsync()
        {
            return await _tableRepository.GetAllAsync();
        }

        public async Task<Table> GetByIdAsync(int tableId)
        {
            return await _tableRepository.GetByIdAsync(tableId);
        }

        public async Task UpdateAsync(Table updatedTable)
        {
            await _tableRepository.UpdateAsync(updatedTable);
        }
    }
}