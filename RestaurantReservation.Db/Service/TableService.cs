using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

namespace RestaurantReservation.Db.Service
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly PaginationMetadataGenerator<Table> _paginationMetadataGenerator = new();


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

        public async Task<(List<Table>, Meta)> GetAllAsync(int page, int pageSize)
        {
            var tables = await _tableRepository.GetAllAsync(page, pageSize);
            var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(tables, page, pageSize);
                
            return (tables, metadata);
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