using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Services
{
    public class RandomUserService
    {
        private readonly HttpClient _httpClient;

        public RandomUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetRandomUserAsync()
        {
            var response = await _httpClient.GetAsync("https://randomuser.me/api/");
            response.EnsureSuccessStatusCode();


            var jsonResponse = await response.Content.ReadAsStringAsync();
            
            var userResult = JsonConvert.DeserializeObject<RandomUserResponse>(jsonResponse);

            if (userResult?.Results != null && userResult.Results.Any())
            {
                var userData = userResult.Results.FirstOrDefault();

                if (userData != null)
                {
                    User user = new User(
                        gender: userData.Gender,
                        title: userData.Name.Title,
                        firstName: userData.Name.First,
                        lastName: userData.Name.Last,
                        email: userData.Email,
                        username: userData.Login.Username,
                        password: userData.Login.Password,
                        salt: userData.Login.Salt,
                        md5: userData.Login.Md5,
                        sha1: userData.Login.Sha1,
                        sha256: userData.Login.Sha256,
                        dateOfBirth: userData.Dob.Date,
                        age: userData.Dob.Age,
                        registeredDate: userData.Registered.Date,
                        registeredAge: userData.Registered.Age,
                        phone: userData.Phone,
                        cell: userData.Cell,
                        idName: userData.Id.Name,
                        idValue: userData.Id.Value,
                        pictureLarge: userData.Picture.Large,
                        pictureMedium: userData.Picture.Medium,
                        pictureThumbnail: userData.Picture.Thumbnail,
                        nationality: userData.Nat,
                        streetNumber: userData.Location.Street.Number,
                        streetName: userData.Location.Street.Name,
                        city: userData.Location.City,
                        state: userData.Location.State,
                        country: userData.Location.Country,
                        postcode: userData.Location.Postcode,
                        latitude: float.Parse(userData.Location.Coordinates.Latitude),
                        longitude: float.Parse(userData.Location.Coordinates.Longitude),
                        timezoneOffset: userData.Location.Timezone.Offset,
                        timezoneDescription: userData.Location.Timezone.Description
                    );

                    return user;
                }
            }

            return null;
        }

        public async Task<List<User>> GetMultipleRandomUserAsync(int number)
        {
            var response = await _httpClient.GetAsync($"https://randomuser.me/api/?results={number}");
            response.EnsureSuccessStatusCode();


            var jsonResponse = await response.Content.ReadAsStringAsync();

            var userResult = JsonConvert.DeserializeObject<RandomUserResponse>(jsonResponse);

            if (userResult?.Results != null && userResult.Results.Any())
            {
                var usersData = userResult.Results.ToList();
                List<User> users = new List<User>();
                if (usersData != null)
                {
                    foreach(UserData userData in usersData )
                    { 
                        User user = new User(
                            gender: userData.Gender,
                            title: userData.Name.Title,
                            firstName: userData.Name.First,
                            lastName: userData.Name.Last,
                            email: userData.Email,
                            username: userData.Login.Username,
                            password: userData.Login.Password,
                            salt: userData.Login.Salt,
                            md5: userData.Login.Md5,
                            sha1: userData.Login.Sha1,
                            sha256: userData.Login.Sha256,
                            dateOfBirth: userData.Dob.Date,
                            age: userData.Dob.Age,
                            registeredDate: userData.Registered.Date,
                            registeredAge: userData.Registered.Age,
                            phone: userData.Phone,
                            cell: userData.Cell,
                            idName: userData.Id.Name,
                            idValue: userData.Id.Value,
                            pictureLarge: userData.Picture.Large,
                            pictureMedium: userData.Picture.Medium,
                            pictureThumbnail: userData.Picture.Thumbnail,
                            nationality: userData.Nat,
                            streetNumber: userData.Location.Street.Number,
                            streetName: userData.Location.Street.Name,
                            city: userData.Location.City,
                            state: userData.Location.State,
                            country: userData.Location.Country,
                            postcode: userData.Location.Postcode,
                            latitude: float.Parse(userData.Location.Coordinates.Latitude),
                            longitude: float.Parse(userData.Location.Coordinates.Longitude),
                            timezoneOffset: userData.Location.Timezone.Offset,
                            timezoneDescription: userData.Location.Timezone.Description
                        );

                        users.Add(user);
                    }

                    return users;
                }
            }

            return null;
        }
    }
}
