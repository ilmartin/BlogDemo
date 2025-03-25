using BlogDemo.Models;

namespace BlogDemo.Service
{
    public class AuthService : IAuthService
    {
        private readonly Dictionary<string, string> _users = new()
    {
        { "admin", "password123" }, // Example users
        { "martin", "securepass" }
    };

        public bool ValidateUser(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }
    }
}
