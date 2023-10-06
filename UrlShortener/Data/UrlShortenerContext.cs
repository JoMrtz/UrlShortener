using Microsoft.EntityFrameworkCore;
using UrlShortener.Entities;

namespace UrlShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
            public DbSet<Url> Url { get; set; }

            public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
            {

            }
      } 
}
