using DTO;
using Entites;
using Medication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserRepository
    {
        public Task <IEnumerable<User>> getAllUsers();
        public Task<User> getUser(string userName, string password);
        public Task<User> getUserById(int userId);
        public Task<User> addUser(User user);
        public Task updateUser(User user);

    }
}
