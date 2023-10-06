using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Entities
{
    public class Url
    {
        [Key]
        public int ID { get; set; }
        public string? UrlOriginal { get; set; }
        public string? UrlShort { get; set; }

    }
}
