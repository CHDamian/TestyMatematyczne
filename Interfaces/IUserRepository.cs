using TestyMatematyczne.Models;

namespace TestyMatematyczne.Interfaces
{
    public interface IUserRepository
    {
        public User GetUser(string id);
        public User GetUserById(string id);
    }
}
