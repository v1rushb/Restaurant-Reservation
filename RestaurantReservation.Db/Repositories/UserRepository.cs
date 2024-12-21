using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Extensions;
using RestaurantReservation.Db.Repositories.interfaces;
using RestaurantReservation.Db.Repositories.Interfaces;

namespace RestaurantReservation.Db.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly RestaurantReservationDbContext _context;

        public UserRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User newUser)
        {
            if(newUser.Id < 0)
            {
                throw new Exception("Id property can not be negative.");
            }

            if(await ExistsAsync(newUser.Id))
            {
                throw new Exception($"User with Id: {newUser.Id} already exists.");
            }

            var user = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task DeleteAsync(int Id)
        {
            var user = await GetByIdAsync(Id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        Task<bool> ExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        async Task<bool> IRepository<User>.ExistsAsync(int userId) =>
            await _context.Users.AnyAsync(user => user.Id.Equals(userId));
        public async Task<List<User>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Users
                .PaginateAsync(page, pageSize);
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(user => user.Id.Equals(userId));

            if(user == null)
            {
                throw new KeyNotFoundException($"User with ID = {userId} does not exist.");
            }

            return user;
        }

        public async Task<int> GetCountAsync()
        {
            if (_context.Users.TryGetNonEnumeratedCount(out var fastCount))
                return fastCount;

            return await _context.Users.CountAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(user => user.Username.Equals(username));
            if(user == null)
            {
                throw new KeyNotFoundException($"User with username {user.Username} does not exist.");
            }
            
            return user;
        }

        public async Task UpdateAsync(User updatedUser)
        {
            if(!(await ExistsAsync(updatedUser.Id)))
            {
                throw new KeyNotFoundException($"User with ID = {updatedUser.Id} does not exist.");
            }

            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();
        }
    }
}