using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using UrlShortener.Data;
using UrlShortener.Entities;
using UrlShortener.Models;
using System.Security.Claims;
namespace UrlShortener.Services
{
    public class UserServices
    {
        private readonly UrlShortenerContext _urlContext;

        public UserServices(UrlShortenerContext urlContext)
        { 
            _urlContext = urlContext;
        }

        public void CreateUser(UserForCreation userForCreation)
        {
            User user = new User()
            {
                Username = userForCreation.Username,
                Password = userForCreation.Password
            };
            _urlContext.Add(user);
            _urlContext.SaveChanges();
        }

    }
}
