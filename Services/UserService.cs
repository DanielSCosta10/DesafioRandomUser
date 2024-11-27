using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await _dbContext.Users.ToListAsync();
            return users;
        }

        public async Task<int> GetUserCount()
        {
            int userCount = await _dbContext.Users.CountAsync();
            return userCount;
        }

        public async Task<User?> GetUser(Guid id)
        {
            User user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<User> UpdateUser(User user, UpdateUserDto updateUserDto)
        {
            try
            {
                var properties = typeof(UpdateUserDto).GetProperties();

                foreach (var property in properties)
                {
                    var userProperty = typeof(User).GetProperty(property.Name);

                    if (userProperty != null && property.GetValue(updateUserDto) != null)
                    {
                        userProperty.SetValue(user, property.GetValue(updateUserDto));
                    }
                }

                await _dbContext.SaveChangesAsync();

                return user; 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
