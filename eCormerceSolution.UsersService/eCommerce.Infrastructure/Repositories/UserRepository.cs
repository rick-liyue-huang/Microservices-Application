using eCommerce.Core.DTO;
using eCommerce.Core.Entity;
using eCommerce.Core.RepositoryContracts;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUsersRepository
    {
        public async Task<ApplicationUser?> IUsersRepository.AddUser(ApplicationUser user)
        {
            // Generate a new unique user id FOR THE USER
            user.UserID = Guid.NewGuid();
            return user;
        }

        public async Task<ApplicationUser?> IUsersRepository.GetUserByEmailAndPassword(string? email, string? password)
        {
            return new ApplicationUser()
            {
                UserID = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "Person name",
                Gender = GenderOptions.Male.ToString(),
            };
        }
    }
}
