using TestyMatematyczne.Data;
using TestyMatematyczne.Interfaces;
using TestyMatematyczne.Models;

namespace TestyMatematyczne.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public User GetUser(string id) 
        {
            return _context.Users.Where(u => u.Email == id).First();
        }
    }
}
