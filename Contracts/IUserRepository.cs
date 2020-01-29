using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUser(string username);
        void CreateUser(User user);
    }
}