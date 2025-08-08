
using Application.Services;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/user-pages")]
    public class UserPageController : ControllerBase
    {
        private readonly UserPageService _userPageService;

        public UserPageController(UserPageService userPageService)
        {
            _userPageService = userPageService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserPageDto>> GetUserPageDetailsAsync(int id)
        {
            var userPageDetails = await _userPageService.GetUserPageDetailsAsync(id);

            if (userPageDetails == null)
            {
                return NotFound();
            }

            return Ok(userPageDetails);
        }
    }
}