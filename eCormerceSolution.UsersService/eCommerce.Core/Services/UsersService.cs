

using eCommerce.Core.DTO;
using eCommerce.Core.Entity;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServicesContracts;

namespace eCommerce.Core.Services
{
    internal class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        async Task<AuthenticationResponse?> IUsersService.Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;
            }

            return new AuthenticationResponse(user.UserID, user.Email, user.PersonName, user.Gender, "token", Success: true);
        }

        async Task<AuthenticationResponse?> IUsersService.Register(RegisterRequest registerRequest)
        {
            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString(),
            };
            ApplicationUser? registerUser = await _usersRepository.AddUser(user);

            if (registerUser == null)
            {
                return null;
            }

            return new AuthenticationResponse(registerUser.UserID, registerUser.Email, registerUser.Email, registerUser.Gender, "token", Success: true);
        }
    }
}
