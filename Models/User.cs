using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;
public class User
{
    [Key]
    public Guid Id { get; init; }
    public string Gender { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Md5 { get; set; }
    public string Sha1 { get; set; }
    public string Sha256 { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get; set; }
    public DateTime RegisteredDate { get; set; }
    public int RegisteredAge { get; set; }
    public string Phone { get; set; }
    public string Cell { get; set; }
    public string IdName { get; set; }
    public string IdValue { get; set; }
    public string PictureLarge { get; set; }
    public string PictureMedium { get; set; }
    public string PictureThumbnail { get; set; }
    public string Nationality { get; set; }
    public int StreetNumber { get; set; }
    public string StreetName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Postcode { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public string TimezoneOffset { get; set; }
    public string TimezoneDescription { get; set; }

    public User( string gender, string title, string firstName, string lastName, string email, string username, string password, string salt, string md5, string sha1, string sha256, DateTime dateOfBirth, int age, DateTime registeredDate, int registeredAge, string phone, string cell, string idName, string idValue, string pictureLarge, string pictureMedium, string pictureThumbnail, string nationality, int streetNumber, string streetName, string city, string state, string country, string postcode, float latitude, float longitude, string timezoneOffset, string timezoneDescription)
    {
        Id = Guid.NewGuid();
        Gender = gender;
        Title = title;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Username = username;
        Password = password;
        Salt = salt;
        Md5 = md5;
        Sha1 = sha1;
        Sha256 = sha256;
        DateOfBirth = dateOfBirth;
        Age = age;
        RegisteredDate = registeredDate;
        RegisteredAge = registeredAge;
        Phone = phone;
        Cell = cell;
        IdName = idName;
        IdValue = idValue;
        PictureLarge = pictureLarge;
        PictureMedium = pictureMedium;
        PictureThumbnail = pictureThumbnail;
        Nationality = nationality;
        StreetNumber = streetNumber;
        StreetName = streetName;
        City = city;
        State = state;
        Country = country;
        Postcode = postcode;
        Latitude = latitude;
        Longitude = longitude;
        TimezoneOffset = timezoneOffset;
        TimezoneDescription = timezoneDescription;

    }

}

public class UpdateUserDto
{
    public string? Gender { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Username { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Phone { get; set; }
    public string? Cell { get; set; }
    public string? PictureLarge { get; set; }
    public string? PictureMedium { get; set; }
    public string? PictureThumbnail { get; set; }
    public string? Nationality { get; set; }
    public string? StreetName { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Postcode { get; set; }
    public float? Latitude { get; set; }
    public float? Longitude { get; set; }
    public string? TimezoneOffset { get; set; }
    public string? TimezoneDescription { get; set; }
}

