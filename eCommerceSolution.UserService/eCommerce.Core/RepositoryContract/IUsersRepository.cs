using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.Entities;

namespace UserService.eCommerce.Core.RepositoryContract
{
    // contract to be implemented by UserRepository that contains data access logic of users data store
    public interface IUsersRepository
    {
        // add a user to the data store and return the user
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
