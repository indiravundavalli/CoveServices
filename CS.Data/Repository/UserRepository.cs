using CS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dataContext)
        {
            _dbContext = dataContext;
        }


        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }
            if (user.RoleId == 1)
                user.Role = new Roles { Name = "Admin" };
            else
                user.Role = new Roles { Name = "Provider" };


            user.Password = null;
            return user;
        }
    }
}
