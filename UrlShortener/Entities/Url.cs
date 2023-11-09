using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Entities
{
    public class Url
    {
        [Key]
        public int ID { get; set; }
        public string? UrlOriginal { get; set; }
        public string? UrlShort { get; set; }
        public int Counter { get; set; }//creamos propiedad count para podder incrementarlo cada vez que se hace una request
        public Categories Categorie { get; set; }//no impacta en la base de datos aca solamente lo usamos para poder navegar por las tablas.
        //porque sino cuando haga la consulta con linq me devolveria solamentre un numero(categories id) y tendria que entrar a la entidad categorias y ver que machee el id que le devolvio con el id que corresponda
        public int CategoriesId {  get; set; }  
    }
}
