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

        public List<User> GetAllUsers()
        {
            List<User> users = _dbContext.Users.ToList();
            return users;
        }

        public User? GetUser(Guid id)
        {
            User user =  _dbContext.Users.Find(id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> UpdateUser(User user, UpdateUserDto updateUserDto)
        {
            try
            {
                if (!string.IsNullOrEmpty(updateUserDto.Gender))
                    user.Gender = updateUserDto.Gender;
                if (!string.IsNullOrEmpty(updateUserDto.Title))
                    user.Title = updateUserDto.Title;
                if (!string.IsNullOrEmpty(updateUserDto.FirstName))
                    user.FirstName = updateUserDto.FirstName;
                if (!string.IsNullOrEmpty(updateUserDto.LastName))
                    user.LastName = updateUserDto.LastName;
                if (!string.IsNullOrEmpty(updateUserDto.Email))
                    user.Email = updateUserDto.Email;
                if (!string.IsNullOrEmpty(updateUserDto.Username))
                    user.Username = updateUserDto.Username;
                if (updateUserDto.DateOfBirth.HasValue)
                    user.DateOfBirth = updateUserDto.DateOfBirth.Value;
                if (!string.IsNullOrEmpty(updateUserDto.Phone))
                    user.Phone = updateUserDto.Phone;
                if (!string.IsNullOrEmpty(updateUserDto.Cell))
                    user.Cell = updateUserDto.Cell;
                if (!string.IsNullOrEmpty(updateUserDto.PictureLarge))
                    user.PictureLarge = updateUserDto.PictureLarge;
                if (!string.IsNullOrEmpty(updateUserDto.PictureMedium))
                    user.PictureMedium = updateUserDto.PictureMedium;
                if (!string.IsNullOrEmpty(updateUserDto.PictureThumbnail))
                    user.PictureThumbnail = updateUserDto.PictureThumbnail;
                if (!string.IsNullOrEmpty(updateUserDto.Nationality))
                    user.Nationality = updateUserDto.Nationality;
                if (!string.IsNullOrEmpty(updateUserDto.StreetName))
                    user.StreetName = updateUserDto.StreetName;
                if (!string.IsNullOrEmpty(updateUserDto.City))
                    user.City = updateUserDto.City;
                if (!string.IsNullOrEmpty(updateUserDto.State))
                    user.State = updateUserDto.State;
                if (!string.IsNullOrEmpty(updateUserDto.Country))
                    user.Country = updateUserDto.Country;
                if (!string.IsNullOrEmpty(updateUserDto.Postcode))
                    user.Postcode = updateUserDto.Postcode;
                if (updateUserDto.Latitude.HasValue)
                    user.Latitude = updateUserDto.Latitude.Value;
                if (updateUserDto.Longitude.HasValue)
                    user.Longitude = updateUserDto.Longitude.Value;
                if (!string.IsNullOrEmpty(updateUserDto.TimezoneOffset))
                    user.TimezoneOffset = updateUserDto.TimezoneOffset;
                if (!string.IsNullOrEmpty(updateUserDto.TimezoneDescription))
                    user.TimezoneDescription = updateUserDto.TimezoneDescription;

                
                await _dbContext.SaveChangesAsync();

                return true; 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
