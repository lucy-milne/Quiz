using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public User GetUser(string username)
        {
            return FindByCondition(user => user.Id.Equals(username)).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }
    }
}
