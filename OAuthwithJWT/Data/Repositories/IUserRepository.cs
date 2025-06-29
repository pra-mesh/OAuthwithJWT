using OAuthwithJWT.Models;

namespace OAuthwithJWT.Data.Repositories;
public interface IUserRepository
{
    Task<User> CreateUserAsync(User user);
}