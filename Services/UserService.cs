using Microsoft.AspNetCore.JsonPatch;
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

        public List<User> GetAllUsers()
        {
            List<User> users = _dbContext.Users.ToList();
            return users;
        }

        public User GetUser(Guid id)
        {
            User user = _dbContext.Users.Find(id);
            return user;
        }

        public bool UpdateUser(Guid id, JsonPatchDocument<User> patchDoc)
        {
            try
            {
                var user = _dbContext.Users.Find(id);
                if (user == null)
                {
                    return false; 
                }

                patchDoc.ApplyTo(user);

                _dbContext.SaveChanges();

                return true; 

            }
            catch
            {
                return false;
            }
        }

    }
}
