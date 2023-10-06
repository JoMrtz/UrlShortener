using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.Utilities;
namespace UrlShortener.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortController : ControllerBase
    {
        private readonly UrlShortenerContext _UrlContext;
        public UrlShortController(UrlShortenerContext UrlContext)
        {
            _UrlContext = UrlContext;
        }
        [HttpPost]
        public IActionResult SendCompleteUrl([FromBody] UrlForConvertionDTO UrlFull)
        {
            string ShortUrl = UrlShortener.Utilities.UrlShortCreator(6);
            return Ok();
        }

        
    }
}
