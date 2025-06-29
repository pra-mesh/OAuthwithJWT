using OAuthwithJWT.Data.Repositories;

namespace OAuthwithJWT.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

}
