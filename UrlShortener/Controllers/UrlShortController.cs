using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
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
        public IActionResult SendCompleteUrl([FromBody] UrlForConvertionDTO UrlFull )//por buenas practicas se manda por body y como es por body el content tyoe de from body es json() entonces 
        {
            string ShortUrl = UrlShortCreator.GenerateShortUrl(6);
            Url url = new Url()
            {
                UrlOriginal = UrlFull.UrlOriginal,
                UrlShort = ShortUrl,
                Counter = 0,
                CategoriesId= UrlFull.idCategoria
            };
            
            _UrlContext.Url.Add(url);
            _UrlContext.SaveChanges();
            // int check = _UrlContext.SaveChanges();

            return Ok(ShortUrl);
        }
        [HttpGet("{ShortUrl}")]//mandar el dato por url 
        public IActionResult GetFullUrl(string ShortUrl)
        {
            var urlhola = _UrlContext.Url.FirstOrDefault(u => u.UrlShort == ShortUrl);
            if (urlhola == null) { 
                return NotFound();
            }
            urlhola.Counter++;
            _UrlContext.Update(urlhola);
            _UrlContext.SaveChanges();

            return Redirect(urlhola.UrlOriginal);

        }
    }
}
