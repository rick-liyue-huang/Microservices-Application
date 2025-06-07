using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.DTOs;

namespace UserService.eCommerce.Core.ServiceContract
{
    // contracts for users services that contains 
    public interface IUsersService
    {
        Task<AuthenticationResponse?> Login(LoginRequest loginRequest);

        Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
    }
}
