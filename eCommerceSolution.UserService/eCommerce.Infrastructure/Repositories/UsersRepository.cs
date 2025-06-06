using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.DTOs;
using UserService.eCommerce.Core.Entities;
using UserService.eCommerce.Core.RepositoryContract;

namespace UserService.eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {
        async Task<ApplicationUser?> IUsersRepository.AddUser(ApplicationUser user)
        {
            // Generate a new unique user ID for the user
            user.UserID = Guid.NewGuid();

            return user;
        }

        async Task<ApplicationUser?> IUsersRepository.GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "person name",
                Gender = GenderOptions.Male.ToString(),
            };
        }
    }
}
