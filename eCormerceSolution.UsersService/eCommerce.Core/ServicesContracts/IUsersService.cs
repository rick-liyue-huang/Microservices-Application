

using eCommerce.Core.DTO;

namespace eCommerce.Core.ServicesContracts
{
    // contracts for users services that contains use cases for users
    public interface IUsersService
    {
        // method to handle user login use case and return an authentication response object that contain status of login
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        // similar way as login
        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
