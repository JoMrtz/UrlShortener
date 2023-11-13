using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _services;
        private readonly UrlShortenerContext _urlContext;

        public UserController(UserServices services, UrlShortenerContext context)
        {
            _services = services;
            _urlContext = context;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreation userForCreation)
        {
            try
            {
                _services.CreateUser(userForCreation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", userForCreation);
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetUrls()
        {
            int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
            var urls = _urlContext.Url.Where(u => u.UserId == userId).ToList();

            return Ok(urls);
        } 

    }
}
