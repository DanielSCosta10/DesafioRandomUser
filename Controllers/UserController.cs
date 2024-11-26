using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly RandomUserService _randomUserService;
        private readonly UserService _userService;
        private readonly AppDbContext _dbContext;

        public UserController(RandomUserService randomUserService, AppDbContext dbContext, UserService userService)
        {
            _randomUserService = randomUserService;
            _userService = userService;
            _dbContext = dbContext;
        }

        
        [ProducesResponseType(typeof(User), 200)]
        [HttpGet]
        public async Task<IActionResult> AddRandomUser()
        {
            try
            {
                var user = await _randomUserService.GetRandomUserAsync();
                if (user == null)
                {
                    return BadRequest("Unable to obtain a valid user from the API.");
                }
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return Ok(user);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Error when calling external API: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error saving user to database: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [ProducesResponseType(typeof(List<User>), 200)]
        [HttpGet]
        public async Task<IActionResult> AddMulipleRandomUser(int number)
        {
            try
            {
                var users = await _randomUserService.GetMultipleRandomUserAsync(number);
                if (users == null)
                {
                    return BadRequest("Unable to get valid API users.");
                }

                _dbContext.Users.AddRange(users);
                await _dbContext.SaveChangesAsync();

                return Ok(users);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(503, $"Error when calling external API: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error saving users to database: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred   : {ex.Message}");
            }
        }

        [ProducesResponseType(typeof(List<User>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                List<User> users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [ProducesResponseType(typeof(User), 200)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                User user = _userService.GetUser(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [ProducesResponseType(204)]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserDto updateUserDto)
        {
            try
            {

                var user = _userService.GetUser(id);
                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }
                var result = await _userService.UpdateUser(user, updateUserDto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
