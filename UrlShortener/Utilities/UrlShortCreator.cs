namespace UrlShortener.Utilities
{
    public class UrlShortCreator
    {
        private static readonly Random random = new Random();
        private const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateShortUrl(int length)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = characters[random.Next(characters.Length)];
            }
            return new string(result);

        }
    }
}
