using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data;
using UrlShortener.Entities;
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
            string ShortUrl = UrlShortCreator.GenerateShortUrl(6);
            Url url = new Url()
            {
                UrlOriginal = UrlFull.UrlOriginal,
                UrlShort = ShortUrl
            };
            _UrlContext.Url.Add(url);
            _UrlContext.SaveChanges();
            // int check = _UrlContext.SaveChanges();

            return Ok(ShortUrl);
        }
        [HttpGet("{ShortUrl}")]
        public IActionResult GetFullUrl(string ShortUrl)
        {
            return Redirect(_UrlContext.Url.Where(u => u.UrlShort == ShortUrl).Select(u => u.UrlOriginal).FirstOrDefault());
        }
    }
}
