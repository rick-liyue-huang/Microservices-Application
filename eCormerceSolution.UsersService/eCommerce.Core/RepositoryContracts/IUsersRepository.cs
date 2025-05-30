using eCommerce.Core.Entity;

namespace eCommerce.Core.RepositoryContracts
{
    // contract to be implemented by UsersRepository that contains data access logic of Users data store
    public interface IUsersRepository
    {
        // Method to add a user to the data store and return the added user
        Task<ApplicationUser?> AddUser(ApplicationUser user);

        // Method to retrieve existing user by its email and password
        Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    }
}
