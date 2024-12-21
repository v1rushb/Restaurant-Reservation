using Microsoft.AspNetCore.Identity;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.Db.Exceptions;
using RestaurantReservation.Db.Repositories.Interfaces;
using RestaurantReservation.Db.Service.Interfaces;
using RestaurantReservation.Db.Utilities;
using RestaurantReservation.Db.Utilities.Models;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly PasswordHasher<string> _passwordHasher = new();
    private readonly PaginationMetadataGenerator<User> _paginationMetadataGenerator;

    public UserService(IUserRepository userRepository)
    {
        _paginationMetadataGenerator = new PaginationMetadataGenerator<User>();
        _userRepository = userRepository;
    }

    public async Task<User?> AuthenticateUserAsync(string username, string password)
    {
        var storedUser = await _userRepository.GetUserByUsernameAsync(username);
        if (storedUser == null)
            return null;

        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(
            username,
            storedUser.Password,
            password
        );

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
            return null;

        return storedUser;
    }

    public async Task<User> CreateAsync(User newUser)
    {
        if (await _userRepository.ContainsUsernameAsync(newUser.Username))
        {
            throw new UsernameDuplicateException(newUser.Username);
        }

        newUser.Password = _passwordHasher.HashPassword(
            newUser.Username,
            newUser.Password
        );

        return await _userRepository.CreateAsync(newUser);
    }

    public async Task DeleteAsync(int userId) =>
        await _userRepository.DeleteAsync(userId);

    public async Task<(List<User>, Meta)> GetAllAsync(int page, int pageSize)
    {
        var users = await _userRepository.GetAllAsync(page, pageSize);
        var metadata = _paginationMetadataGenerator.GetGeneratedMetadata(users, page, pageSize);

        return (users, metadata);
    }

    public async Task<User?> GetByIdAsync(int userId) =>
        await _userRepository.GetByIdAsync(userId);

    public async Task UpdateAsync(User updatedUser)
    {
        if (!string.IsNullOrWhiteSpace(updatedUser.Password))
        {
            updatedUser.Password = _passwordHasher.HashPassword(
                updatedUser.Username,
                updatedUser.Password
            );
        }

        await _userRepository.UpdateAsync(updatedUser);
    }
}
