using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data;
using UrlShortener.Entities;
using UrlShortener.Models;
using UrlShortener.Utilities;

namespace UrlShortener.Controllers
    //contexto en los servicios??? seguramente voy a tener que hacer servicios
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
        public IActionResult SendCompleteUrl([FromBody] UrlForConvertionDTO UrlFull)//por buenas practicas se manda por body y como es por body el content tyoe de from body es json() entonces 
        {
            string ShortUrl = UrlShortCreator.GenerateShortUrl(6);
            Url url = new Url()
            {
                UrlOriginal = UrlFull.UrlOriginal,
                UrlShort = ShortUrl,
                Counter = 0,
                CategoriesId= 1 
            };
            _UrlContext.Url.Add(url);
            _UrlContext.SaveChanges();
            // int check = _UrlContext.SaveChanges();

            return Ok(ShortUrl);
        }
        [HttpGet("{ShortUrl}")]//mandar el dato por url 
        //
        public IActionResult GetFullUrl(string ShortUrl)
        {
           

            return Redirect(_UrlContext.Url.Where(u => u.UrlShort == ShortUrl).Select(u => u.UrlOriginal).FirstOrDefault());

        }
    }
}
