using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using Presentation.Models.Requests;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAll()
        {
            _logger.LogInformation("Attempting to get all authors.");
            var authors = await _authorService.GetAllAsync();
            _logger.LogInformation($"Successfully retrieved {authors.Count()} authors.");
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetByIdAsync(int id)
        {
            try
            {
                var author = await _authorService.GetByIdAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                return Ok(author);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> PostAuthor([FromBody] CreateAuthorRequest request)
        {
            try
            {
                
                var existing = await _authorService.GetByPenNameAsync(request.PenName!);
                if (existing != null) return BadRequest("PenName already exists.");

                var result = await _authorService.CreateAuthorWithPasswordAsync(request.PenName!, request.Email!, request.Password!);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating author.");
                return BadRequest("Failed to create author.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Author request, int id)
        {
            try
            {
                var requestedAuthor = await _authorService.GetByIdAsync(id);
                if (requestedAuthor == null) {  return NotFound(); }

                return Ok(await _authorService.UpdateAsync(request));

            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var author = await _authorService.GetByIdAsync(id);
                if (author == null) return NotFound();

                await _authorService.DeleteAsync(id); 
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

    
