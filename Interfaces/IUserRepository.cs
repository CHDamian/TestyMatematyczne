using TestyMatematyczne.Models;

namespace TestyMatematyczne.Interfaces
{
    public interface IUserRepository
    {
        public User GetUser(string id);
    }
}
