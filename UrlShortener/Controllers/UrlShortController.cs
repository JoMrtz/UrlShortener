using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public IActionResult SendCompleteUrl([FromBody] UrlForConvertionDTO UrlFull )//por buenas practicas se manda por body y como es por body el content tyoe de from body es json() entonces 
        {
            
            var urlexist= _UrlContext.Url.FirstOrDefault(u=> u.UrlOriginal == UrlFull.UrlOriginal);
            if ( urlexist == null) {
                int userId = int.Parse(User.Claims.First(x => x.Type == "id").Value);
                string ShortUrl = UrlShortCreator.GenerateShortUrl(6);
                Url url = new Url()
                {
                    UrlOriginal = UrlFull.UrlOriginal,
                    UrlShort = ShortUrl,
                    Counter = 0,
                    CategoriesId= UrlFull.idCategoria,
                    UserId = userId

                };
            
                _UrlContext.Url.Add(url);
                _UrlContext.SaveChanges();
             // int check = _UrlContext.SaveChanges();

            return Ok(ShortUrl);
            }
            return BadRequest();
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
