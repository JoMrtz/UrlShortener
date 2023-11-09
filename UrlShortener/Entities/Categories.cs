namespace UrlShortener.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Url> Urls { get; set; } //forma de pasar como parametro un tipo de dato y usamos la interfaz de IEnumerable porque nos permite usar muchos metodos que si usaramos un tipo de dato mas normalito no tendriamos
    }
}
