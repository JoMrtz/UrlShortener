using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Entities
{
    public class Url
    {
        [Key]
        public int ID { get; set; }
        public int UrlOriginal { get; set; }
        public int UrlShort { get; set; }

    }
}
