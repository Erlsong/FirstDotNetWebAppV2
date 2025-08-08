using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;

using Application.Models.Requests;
using Application.Models.Responses;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            _logger.LogInformation("Attempting to get all authors.");
            var authors = await _userService.GetAllAsync();
            _logger.LogInformation($"Successfully retrieved {authors.Count()} authors.");
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByIdAsync(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        //var albums = await _albumService.GetByUserId(id);
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserRequest request)
        {
            try
            {
                
                var existing = await _userService.GetByEmailAsync(request.Email!);
                if (existing != null) return BadRequest("PenName already exists.");

                var result = await _userService.CreateUserWithPasswordAsync(request.PenName!, request.Email!, request.Password!);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user.");
                return BadRequest("Failed to create user.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateUserRequest request)
        {
            try
            {
                var existingUser = await _userService.GetByIdAsync(id);
                if (existingUser == null)
                    return NotFound();

                
                if (!string.IsNullOrWhiteSpace(request.PenName))
                    existingUser.PenName = request.PenName;

                if (!string.IsNullOrWhiteSpace(request.Email))
                    existingUser.Email = request.Email;

                if (!string.IsNullOrWhiteSpace(request.Password))
                    existingUser.HashedPassword = _userService.HashPassword(request.Password); 

                var result = await _userService.UpdateAsync(existingUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user.");
                return BadRequest("Failed to update user.");
            }
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null) return NotFound();

                await _userService.DeleteAsync(id); 
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

    
