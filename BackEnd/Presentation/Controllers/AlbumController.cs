using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using Presentation.Models.Requests;
using System.Security.Claims;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;
        private readonly ILogger<AlbumController> _logger;

        public AlbumController(IAlbumService albumService, ILogger<AlbumController> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }


   
        [HttpGet("All-By-Author/{authorId}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAllByAuthor(int authorId)
        {
            _logger.LogInformation($"Attempting to get all Albums from Author with AuthorID: {authorId}.");
            var Albums = await _albumService.GetAllByAuthorAsync(authorId);
            _logger.LogInformation($"Successfully retrieved {Albums.Count()} Albums.");
            return Ok(Albums);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetByIdAsync(int id)
        {
            try
            {
                var Album = await _albumService.GetByIdAsync(id);
                if (Album == null)
                {
                    return NotFound();
                }

                return Ok(Album);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating an album: {Error}", ex.Message);

                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostAlbum([FromBody] AlbumRequest request)
        {
            try
            {
                _logger.LogInformation($"PostAlbum: {request}");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null) return Unauthorized();

                var album = new Album
                {
                    Name = request.Name!,
                    Description = request.Description!,
                    Count = 0,
                    AuthorId = int.Parse(userIdClaim.Value)
                };


                var result = await _albumService.CreateAsync(album);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Album.");
                return Problem("An error occurred while creating the album.", statusCode: 500);

            }
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] AlbumRequest request)
        {
            try
            {
                _logger.LogInformation($"Updating Album: {id}");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingAlbum = await _albumService.GetByIdAsync(id);
                if (existingAlbum == null)
                    return NotFound();

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null) return Unauthorized();

                int userId = int.Parse(userIdClaim.Value);
                if (existingAlbum.AuthorId != userId)
                {
                    return Unauthorized("You do not own this album.");
                }


                if (!string.IsNullOrWhiteSpace(request.Name))
                    existingAlbum.Name = request.Name;

                if (!string.IsNullOrWhiteSpace(request.Description))
                    existingAlbum.Description = request.Description;

                var result = await _albumService.UpdateAsync(existingAlbum);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Album.");
                return BadRequest("Failed to update Album.");
            }
        }


        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var album = await _albumService.GetByIdAsync(id);
                if (album == null) return NotFound();

                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null) return Unauthorized();

                int userId = int.Parse(userIdClaim.Value);
                if (album.AuthorId != userId)
                {
                    return Unauthorized("You do not own this album.");
                }



                await _albumService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}


