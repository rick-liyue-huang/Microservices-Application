using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.DTOs;
using UserService.eCommerce.Core.Entities;
using UserService.eCommerce.Core.RepositoryContract;
using UserService.eCommerce.Core.ServiceContract;


namespace UserService.eCommerce.Core.Services
{
    public class UsersService : IUsersService
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
            // create a new application user object from register request.
            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString(),
            };

            ApplicationUser? registeredUser = await _usersRepository.AddUser(user);

            if (registeredUser == null)
            {
                return null;
            }

            return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender.ToString(), "token", Success: true);
        }
    }
}
