using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entites;
using Medication;

namespace Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> getAllUsers();   
        public Task<User> getUser(string userName, string password);
        public Task<User> getUserById(int userId);
        public Task<User> addUser(User user);
        public Task updateUser(User user);

    }
}
