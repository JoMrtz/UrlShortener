using Microsoft.EntityFrameworkCore;
using UrlShortener.Entities;

namespace UrlShortener.Data
{
    public class UrlShortenerContext : DbContext
    {
            public DbSet<Url> Url { get; set; }
            public DbSet<Categories> Categories { get; set; }

            public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
            {
                
            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>().HasOne(c => c.Categorie).WithMany(u => u.Urls).HasForeignKey(i => i.CategoriesId);//esto seria usando fluent api 
            modelBuilder.Entity<Categories>().HasData(
              new Categories() { Id = 1, Name = "Heores"},
              new Categories() { Id = 2, Name = "Accion"},
              new Categories() { Id = 3, Name = "Gatos"}
            );
        }

      }
}
