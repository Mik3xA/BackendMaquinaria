using API.Models;
using BCrypt.Net;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Users.Any(u => u.Email == "admin@renta.com"))
            {
                return; 
            }
            var admin = new User
            {
                Name = "El Patron",
                Email = "admin@renta.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Role = "Admin"
            };

            context.Users.Add(admin);
            context.SaveChanges();
        }
    }
}