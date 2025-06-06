using UserService.eCommerce.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.DTOs;
using UserService.eCommerce.Core.Entities;
using UserService.eCommerce.Core.RepositoryContract;
using Dapper;

namespace UserService.eCommerce.Infrastructure.Repositories
{
    internal class UsersRepository : IUsersRepository
    {

        private readonly DapperDbContext _dapperDbContext;

        public UsersRepository(DapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        async Task<ApplicationUser?> IUsersRepository.AddUser(ApplicationUser user)
        {
            // Generate a new unique user ID for the user
            user.UserID = Guid.NewGuid();

            // SQL Query to insert user data into the 'Users' table

            //string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
            string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
            int rowCountAffected = await _dapperDbContext.dbConnection.ExecuteAsync(query, user);

            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }

            
        }

        async Task<ApplicationUser?> IUsersRepository.GetUserByEmailAndPassword(string? email, string? password)
        {

            // sql query to select a user
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new { Email = email, Password = password };
            
            ApplicationUser? user = await _dapperDbContext.dbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);


            return user;

        }
    }
}
