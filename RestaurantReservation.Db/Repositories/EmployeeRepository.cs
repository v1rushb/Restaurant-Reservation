using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Repositories.interfaces;

namespace RestaurantReservation.Db.Repositories 
{
    public class EmployeeRepository : IEmployeeRepository
    {
        Task<int> IRepository<Employee>.CreateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository<Employee>.DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<List<Employee>> IRepository<Employee>.GetAllAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        Task<Employee> IRepository<Employee>.GetByIdAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Employee>.GetCountAsync()
        {
            throw new NotImplementedException();
        }

        Task IRepository<Employee>.UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}